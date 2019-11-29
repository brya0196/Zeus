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

            subjectToUpdate.Course = subject.Course;
            subjectToUpdate.CurrentRoom = subject.CurrentRoom;
            subjectToUpdate.MaximumRoom = subject.MaximumRoom;
            subjectToUpdate.TimeStart = subject.TimeStart;
            subjectToUpdate.TimeEnds = subject.TimeEnds;
            subjectToUpdate.Name = subject.Name;
            subjectToUpdate.Days = subject.Days;
            subjectToUpdate.DateStart = subject.DateStart;
            subjectToUpdate.DateEnds = subject.DateEnds;
            subjectToUpdate.Code = subject.Code;
            subjectToUpdate.CodeRequirement = subject.CodeRequirement;
            subjectToUpdate.updated_at = DateTime.Now;

            _context.Subjects.Update(subjectToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}