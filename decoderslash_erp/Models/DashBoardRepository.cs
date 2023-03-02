using decoderslash_erp.Data;
using Microsoft.EntityFrameworkCore;

namespace decoderslash_erp.Models
{
    public class DashBoardRepository
    {
        private readonly decoderslash_erpContext _context;

        public DashBoardRepository(decoderslash_erpContext context, int User_Id)
        {
            _context = context;
            _context.UserId = User_Id;
        }
        public static List<CardSectionModel> MakeEmployeeSectionsList()
        {
            List<CardModelLeft> cards = new List<CardModelLeft>();
            cards.Add(new CardModelLeft
            {
                Counter = 1,
                Tag = "Team Details",
                Icon = "icon-pencil primary",
                Types = "Left",
                Controller = "Employee",
                Action = "TeamDetails"
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
                Controller = "Employee",
                Types = "Left",
                Action = "ShowDetails"
            });

            List<List<CardModelLeft>> data = new List<List<CardModelLeft>>();
            data.Add(cards);
            //data.Add(cards1);

            CardSectionModel cardSection = new CardSectionModel()
            {
                Head = "Site Controls",
                Tag = "Hoady Brother Choose one of the Option :)",
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
                Controller = "Admin",
                Action = "SearchEmployee"
            });

            cards.Add(new CardModelLeft
            {
                Counter = 3,
                Tag = "Delete Employee",
                Icon = "icon-book-open primary",
                Types = "Left",
                Controller = "Admin",
                Action = "DeleteEmployee"
            });

            cards.Add(new CardModelLeft
            {
                Counter = 4,
                Tag = "Add Team",
                Icon = "icon-pencil primary",
                Types = "Left",
                Controller = "Admin",
                Action = "AddTeam"
            });

            cards.Add(new CardModelLeft
            {
                Counter = 5,
                Tag = "Add Project",
                Icon = "icon-pencil primary",
                Types = "Left",
                Controller = "Admin",
                Action = "AddProject"
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
    }
}
