﻿using System;
using Core.Interfaces;

namespace Core.Base
{
    public interface IUnitOfWork : IDisposable
    {
        ICourseRepository CourseRepository { get; }
        IGenderRepository GenderRepository { get; }
        IStatusRepository StatusRepository { get; }
        IUserTypeRepository UserTypeRepository { get; }
        ISubjectRepository SubjectRepository { get; }
        IUserRepository UserRepository { get; }
        ICoursesUsersRepository CoursesUsersRepository { get; }
    }
}