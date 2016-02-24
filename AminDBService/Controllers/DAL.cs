using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using AminDBService.Models;

namespace AminDBService.Controllers
{
    public class DAL
    {
        private AminDBServiceContext context = new AminDBServiceContext();

        private List<string> personList = new List<string>();

        private static DAL instance = null;

        private DAL()
        {
        }

        public static DAL Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DAL();

                    //Init();
                }
                return instance;
            }
        }

        public List<string> GetPersonList()
        {
            var members = context.Members.ToList();
            return members.Select(member => member.Name).ToList();
        }

        public bool AddPerson(string person)
        {
            if (IsPersonExist(person) == false)
            {
                var newMember = new Member() {Name = person};
                context.Members.Add(newMember);
                context.SaveChanges();
            }

            return true;
        }

        public void RemovePerson(string person)
        {
            if (IsPersonExist(person))
            {
                Member member = context.Members.Single(x => x.Name.Equals(person));
                context.Members.Remove(member);
                context.SaveChanges();
            }
        }

        public bool IsPersonExist(string person)
        {
            var members = context.Members.ToList();
            var retVal = members.Exists(x => x.Name.Equals(person));
            return retVal;
        }
        

        //private int CreateMemberId()
        //{
        //    var maxMemberId = context.Members.ToList().Max(x => x.MemberId);

        //    return ++maxMemberId;
        //}

    }
}