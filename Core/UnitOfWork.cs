using Core.Base;
using Core.Interfaces;
using Core.Repositories;
using Data;

namespace Core
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ZeusDbContext _context;

        public UnitOfWork(ZeusDbContext context)
        {
            _context = context;
            
            CourseRepository = new CourseRepository(_context);
            GenderRepository = new GenderRepository(_context);
            StatusRepository = new StatusRepository(_context);
            UserTypeRepository = new UserTypeRepository(_context);
            SubjectRepository = new SubjectRepository(_context);
            UserRepository = new UserRepository(_context);
            CareerRepository = new CareerRepository(_context);
            CareerSubjectRepository = new CareerSubjectRepository(_context);
            PeriodRepository = new PeriodRepository(_context);
            SectionRepository = new SectionRepository(_context);
            SubscriptionRepository = new SubscriptionRepository(_context);
        }

        public async void Dispose()
        {
           await _context.DisposeAsync();
        }

        public ICourseRepository CourseRepository { get; }
        public IGenderRepository GenderRepository { get; }
        public IStatusRepository StatusRepository { get; }
        public IUserTypeRepository UserTypeRepository { get; }
        public ISubjectRepository SubjectRepository { get; }
        public IUserRepository UserRepository { get; }
        public ICareerRepository CareerRepository { get; }
        public ICareerSubjectRepository CareerSubjectRepository { get; }
        public IPeriodRepository PeriodRepository { get; }
        public ISectionRepository SectionRepository { get; }
        public ISubscriptionRepository SubscriptionRepository { get; }
    }
}