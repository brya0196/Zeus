using System.Collections.Generic;
using System.Linq;
using Data.Entities;
using GenFu;

namespace Test.Mock
{
    public class MockData
    {
        public static IEnumerable<User> GetFakeUsers()
        {
            var i = 1;
            var users = A.ListOf<User>(5);
            users.ForEach(x => x.Id = i++);
            return users.Select(x => x);
        }

        public static IEnumerable<Section> GetFakeSections()
        {
            var i = 1;
            var sections = A.ListOf<Section>(5);
            sections.ForEach(x => x.Id = i++);
            return sections.Select(x => x);
        }
    }
}