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
            CoursesUsersRepository = new CoursesUsersRepository(_context);
            CareerRepository = new CareerRepository(_context);
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
        public ICoursesUsersRepository CoursesUsersRepository { get; }
        public ICareerRepository CareerRepository { get; }
    }
}