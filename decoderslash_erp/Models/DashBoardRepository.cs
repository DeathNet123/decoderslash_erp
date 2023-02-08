using decoderslash_erp.Data;
using Microsoft.EntityFrameworkCore;

namespace decoderslash_erp.Models
{
    public class DashBoardRepository
    {
        private readonly decoderslash_erpContext _context;

        public DashBoardRepository(decoderslash_erpContext context)
        {
            _context = context;
        }
        public static List<CardSectionModel> MakeEmployeeSectionsList()
        {
            List<CardModelLeft> cards = new List<CardModelLeft>();
            cards.Add(new CardModelLeft
            {
                Counter = 1,
                Tag = "Projects",
                Icon = "icon-pencil primary",
                Types = "Left",
                Controller = "#",
                Action = "#"
            });

            cards.Add(new CardModelLeft
            {
                Counter = 2,
                Tag = "Tasks",
                Icon = "icon-user success",
                Types = "Right",
                Controller = "#",
                Action = "#"
            });

            cards.Add(new CardModelLeft
            {
                Counter = 3,
                Tag = "Show Details",
                Icon = "icon-book-open primary",
                Controller = "#",
                Types = "Left",
                Action = "#"
            });

            List<List<CardModelLeft>> data = new List<List<CardModelLeft>>();
            data.Add(cards);
            //data.Add(cards1);

            CardSectionModel cardSection = new CardSectionModel()
            {
                Head = "Site Controls",
                Tag = "Admins Love Controlling Systems :)",
                Rows = 1,
                Data = data
            };

            List<CardSectionModel> cardsectionlist = new List<CardSectionModel>();
            cardsectionlist.Add(cardSection);
            //cardsectionlist.Add(cardSection1);

            return cardsectionlist;
        }
        public static List<CardSectionModel> MakeAdminSectionsList()
        {
            List<CardModelLeft> cards = new List<CardModelLeft>();
            cards.Add(new CardModelLeft
            {
                Counter = 1,
                Tag = "Add Employee",
                Icon = "icon-pencil primary",
                Types = "Left",
                Controller = "SignUp",
                Action = "Index"
            });

            cards.Add(new CardModelLeft
            {
                Counter = 2,
                Tag = "Show Employee",
                Icon = "icon-user success",
                Types = "Right",
                Controller = "EmployeeDashBoard",
                Action = "SearchEmployee"
            });

            cards.Add(new CardModelLeft
            {
                Counter = 3,
                Tag = "Delete Employee",
                Icon = "icon-book-open primary",
                Types = "Left",
                Controller = "EmployeeDashBoard",
                Action = "DeleteEmployee"
            });

            List<List<CardModelLeft>> data = new List<List<CardModelLeft>>();
            data.Add(cards);

            CardSectionModel cardSection = new CardSectionModel()
            {
                Head = "Site Admin Controls",
                Tag = "Admins Love Controlling Systems :)",
                Rows = 1,
                Data = data
            };

            List<CardSectionModel> cardsectionlist = new List<CardSectionModel>();
            cardsectionlist.Add(cardSection);
            //cardsectionlist.Add(cardSection1);

            return cardsectionlist;
        }
        public static List<CardSectionModel> MakeProjectManagerSectionsList()
        {
            List<CardModelLeft> cards = new List<CardModelLeft>();
            cards.Add(new CardModelLeft
            {
                Counter = 278,
                Tag = "Add New User",
                Icon = "icon-pencil primary",
                Types = "Left",
                Controller = "SignUp",
                Action = "Index"
            });

            cards.Add(new CardModelLeft
            {
                Counter = 156,
                Tag = "New Clients",
                Icon = "icon-user success",
                Types = "Right",
                Controller = "#",
                Action = "#"
            });

            cards.Add(new CardModelLeft
            {
                Counter = 278,
                Tag = "New Posts",
                Icon = "icon-book-open primary",
                Controller = "#",
                Types = "Progress",
                Volume = "10",
                Action = "#"
            });

            List<CardModelLeft> cards1 = new List<CardModelLeft>();
            cards1.Add(new CardModelLeft
            {
                Counter = 278,
                Tag = "Another Row of cards",
                Icon = "icon-pencil primary",
                Types = "Left",
                Controller = "SignUp",
                Action = "Index"
            });

            cards1.Add(new CardModelLeft
            {
                Counter = 156,
                Tag = "New Row",
                Icon = "icon-user success",
                Types = "Right",
                Controller = "#",
                Action = "#"
            });


            List<List<CardModelLeft>> data = new List<List<CardModelLeft>>();
            data.Add(cards);
            data.Add(cards1);

            CardSectionModel cardSection = new CardSectionModel()
            {
                Head = "Site Controls",
                Tag = "Admins Love Controlling Systems :)",
                Rows = 2,
                Data = data
            };

            List<CardModelLeft> cards2 = new List<CardModelLeft>();
            cards2.Add(new CardModelLeft
            {
                Counter = 278,
                Tag = "Add New User",
                Icon = "icon-pencil primary",
                Types = "Left",
                Controller = "SignUp",
                Action = "Index"
            });

            cards2.Add(new CardModelLeft
            {
                Counter = 156,
                Tag = "New Clients",
                Icon = "icon-user success",
                Types = "Right",
                Controller = "#",
                Action = "#"
            });

            List<CardModelLeft> cards3 = new List<CardModelLeft>();
            cards3.Add(new CardModelLeft
            {
                Counter = 278,
                Tag = "Another Row of cards",
                Icon = "icon-pencil primary",
                Types = "Left",
                Controller = "SignUp",
                Action = "Index"
            });

            List<List<CardModelLeft>> data1 = new List<List<CardModelLeft>>();
            data1.Add(cards2);
            data1.Add(cards3);

            CardSectionModel cardSection1 = new CardSectionModel()
            {
                Head = "Second Section Testing",
                Tag = "This design is tricking my mind ;)",
                Rows = 2,
                Data = data1
            };


            List<CardSectionModel> cardsectionlist = new List<CardSectionModel>();
            cardsectionlist.Add(cardSection);
            cardsectionlist.Add(cardSection1);

            return cardsectionlist;
        }
        public Employee? SearchEmployee(int id)
        {
            Employee? emp = _context.Employees.FirstOrDefault((Employee emp) => emp.ID.Equals(id));
            return emp;
        }
        public int DeleteEmployee(int id)
        {
            Employee? emp = _context.Employees.FirstOrDefault((Employee emp) => emp.ID.Equals(id));
            if (emp == null)
            {
                return 0;
            }
            int cred_id = emp.CredentialsID;
            Credentials cred = _context.Credentials.FirstOrDefault((cred) => cred.ID == cred_id)!;
            _context.Employees.Remove(emp);
            _context.Credentials.Remove(cred);
            _context.SaveChanges();
            return 1;
        }
    }
}
