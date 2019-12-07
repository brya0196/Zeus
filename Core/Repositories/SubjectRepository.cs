using System;
using System.Threading.Tasks;
using Core.Base;
using Core.Interfaces;
using Data;
using Data.Entities;

namespace Core.Repositories
{
    public class SubjectRepository : BaseRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(ZeusDbContext context) : base(context)
        {
        }

        public async Task Update(Subject subject)
        {
            var subjectToUpdate = await Get(subject.Id);
            
            subjectToUpdate.Name = subject.Name;
            subjectToUpdate.Code = subject.Code;
            subjectToUpdate.CodeRequirement = subject.CodeRequirement;
            subjectToUpdate.UpdatedAt = DateTime.Now;

            _context.Subjects.Update(subjectToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}