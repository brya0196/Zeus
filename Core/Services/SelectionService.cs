using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Base;
using Core.Interfaces;
using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Services
{
    public class SelectionService : ISelectionService
    {
        private readonly ZeusDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public SelectionService(ZeusDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Section> GetCurrentSelection(int UserId, int CareerId)
        {
            var subscriptions = GetSubscriptions(UserId);
            var subjects = GetSubjects(CareerId);
            var availableSubjects = GetAvailableSubjects(subjects, subscriptions);
            var availableSections = GetSections(availableSubjects);

            return availableSections;
        }

        public Subscription GetCurrentSubscription(int UserId)
        {
            return _context.Subscriptions
                .Include(x => x.SubscriptionSections)
                .ThenInclude(x => x.Section)
                .AsEnumerable()
                .Last(X => X.UserId == UserId);
        }

        public async Task AddSubscription(Subscription subscription, List<SubscriptionSection> subscriptionSections)
        {
            _context.Subscriptions.Add(subscription);
            _context.SubscriptionSections.AddRange(subscriptionSections);
            await _context.SaveChangesAsync();
        }

        public List<Subscription> GetSubscriptions(int UserId)
        {
            var subscriptions = _context.Subscriptions
                .Include(x => x.SubscriptionSections)
                .ThenInclude(x => x.Subscription)
                .ThenInclude(x => x.SubscriptionSections)
                .ThenInclude(x => x.Section)
                .ThenInclude(x => x.Subject)
                .Where(x => x.UserId == UserId)
                .ToList();

            return subscriptions;
        }

        public List<Subject> GetSubjects(int CarrerId)
        {
            return _context.Subjects
                .Include(x => x.CareerSubjects)
                .Include(x => x.Sections)
                .Where(x => x.CareerSubjects.Any(x => x.CareerId == CarrerId)).ToList();
        }

        private IEnumerable<Subject> GetAvailableSubjects(List<Subject> subjects, List<Subscription> subscriptions)
        {
            var availableSubjects = new List<Subject>();

            var lastSubscription = subscriptions.Last();

            foreach (var vSubject in subjects)
            {
                var isCodeRequirementValid =
                    lastSubscription.SubscriptionSections.Any(x => x.Section.Subject.Code == vSubject.CodeRequirement);

                var isFinish = subscriptions.Any(x =>
                    x.SubscriptionSections.Any(x => x.Section.Subject.Code == vSubject.Code));

                var isPeriodValid = vSubject.CareerSubjects.Any(x => x.PeriodId == lastSubscription.PeriodId + 1);

                if (isPeriodValid || isCodeRequirementValid || !isFinish)
                {
                    availableSubjects.Add(vSubject);
                }
            }

            return availableSubjects;
        }

        private IEnumerable<Section> GetSections(IEnumerable<Subject> availableSubjects)
        {
            var sections = new List<Section>();

            foreach (var vSubject in availableSubjects)
            {
                if (vSubject.Sections.Count() > 0)
                {
                    var sectionsToAdd = vSubject.Sections.ToList();
                    sections.AddRange(sectionsToAdd);
                }
            }

            return sections;
        }
    }
}