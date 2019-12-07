using System;
using System.Threading.Tasks;
using Core.Base;
using Core.Interfaces;
using Data;
using Data.Entities;

namespace Core.Repositories
{
    public class SectionRepository : BaseRepository<Section>, ISectionRepository
    {
        public SectionRepository(ZeusDbContext context) : base(context)
        {
        }

        public async Task Update(Section section)
        {
            var sectionToUpdate = await Get(section.Id);
            
            sectionToUpdate.Course = section.Course;
            sectionToUpdate.CurrentRoom = section.CurrentRoom;
            sectionToUpdate.MaximumRoom = section.MaximumRoom;
            sectionToUpdate.TimeStart = section.TimeStart;
            sectionToUpdate.TimeEnds = section.TimeEnds;
            sectionToUpdate.Days = section.Days;
            sectionToUpdate.DateStart = section.DateStart;
            sectionToUpdate.DateEnds = section.DateEnds;
            sectionToUpdate.CourseId = section.CourseId;
            sectionToUpdate.SubjectId = section.SubjectId;
            sectionToUpdate.UpdatedAt = DateTime.Now;

            _context.Sections.Update(sectionToUpdate);
            await _context.SaveChangesAsync();
        }
    }
}