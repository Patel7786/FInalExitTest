using BookEvent.DatabaseConnectivity;
using BookEvent.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BookEvent.Repository
{
    public class EventRepository
    {
        private readonly EventContext _Context = null;
        public EventRepository(EventContext context)
        {
            _Context = context;
        }
        public async Task<int> create(BookEventModel model)
        {
            var newevent = new Event()
            {
                UserId = model.UserId,
                EventId = model.EventId,
                Type = model.Type,
                Description = model.Description,
                StartTime = model.StartTime,
                Title = model.Title,
                Date = model.Date,
                Location = model.Location,
                Duration = model.Duration,
                OtherDetails = model.OtherDetails,
                InviteByEmail = model.InviteByEmail,
                Count = model.Count,
                CommentAdded = model.CommentAdded,
                
            };

            await _Context.Events.AddAsync(newevent);
            await _Context.SaveChangesAsync();

            return newevent.EventId;
        }

        public async Task<int> Edit(BookEventModel model)
        {
           
            var StudentData = _Context.Events.Where(x => x.EventId == model.EventId).FirstOrDefault();
            if (StudentData != null)
            {
                StudentData.UserId = model.UserId;
                StudentData.EventId = model.EventId;
                StudentData.Type = model.Type;
                StudentData.Description = model.Description;
                StudentData.StartTime = model.StartTime;
                StudentData.Title = model.Title;
                
                StudentData.Date = model.Date;
                StudentData.Location = model.Location;
                StudentData.Duration = model.Duration;
                StudentData.OtherDetails = model.OtherDetails;
                StudentData.InviteByEmail = model.InviteByEmail;
                StudentData.Count = model.Count;
                StudentData.CommentAdded = model.CommentAdded;
                _Context.Entry(StudentData).State = EntityState.Modified;
                _Context.SaveChanges();
            }


            

            return StudentData.EventId;
        }

        public async Task<List<BookEventModel>> HomePastEvent()
        {
            var books = new List<BookEventModel>();
            var allbooks =  _Context.Events.ToList();
            if (allbooks?.Any() == true)
            {
                foreach (Event d in allbooks)
                {
                    if (d.Date<DateTime.Now && d.Type!=2)
                    {
                        books.Add(
                            new BookEventModel()
                            {
                                UserId=d.UserId,
                                Title = d.Title,
                                EventId=d.EventId,
                                Description=d.Description,
                                Date=d.Date,
                                StartTime=d.StartTime,

                            }) ;
                    }
                }
                return books;
            }
            return null;
        }


        public async Task<List<BookEventModel>> Myevent(string Id)
        {
            var books = new List<BookEventModel>();
            var allbooks = _Context.Events.ToList();
            if (allbooks?.Any() == true)
            {
                foreach (Event d in allbooks)
                {
                    if (d.UserId != null && d.UserId.Equals(Id))
                    {
                        books.Add(
                            new BookEventModel()
                            {
                                UserId = d.UserId,
                                Title = d.Title,
                                EventId = d.EventId,
                                Description = d.Description,
                                Date = d.Date,
                                StartTime = d.StartTime,

                            });
                    }
                }
                return books;
            }
            return null;
        }

        public async Task<List<BookEventModel>> EventInvitedTo(string Id)
        {
            var books = new List<BookEventModel>();
            var allbooks = _Context.Events.ToList();
            if (allbooks?.Any() == true)
            {
                foreach (Event d in allbooks)
                {
                    if (d.InviteByEmail != null && d.InviteByEmail.Equals(Id))
                    {
                        books.Add(
                            new BookEventModel()
                            {
                                UserId = d.UserId,
                                Title = d.Title,
                                EventId = d.EventId,
                                Description = d.Description,
                                Date = d.Date,
                                StartTime = d.StartTime,

                            });
                    }
                }
                return books;
            }
            return null;
        }



        public async Task<List<BookEventModel>> TotalEvent()
        {
            var books = new List<BookEventModel>();
            var allbooks = _Context.Events.ToList();
            if (allbooks?.Any() == true)
            {
                foreach (Event d in allbooks)
                {
                        books.Add(
                            new BookEventModel()
                            {
                                UserId = d.UserId,
                                Title = d.Title,
                                EventId = d.EventId,
                                Description = d.Description,
                                Date = d.Date,
                                StartTime = d.StartTime,

                            });
                    
                }
                return books;
            }
            return null;
        }



        public async Task<BookEventModel> ViewDetails(int Id)
        {
            var allbooks = _Context.Events.ToList();
            BookEventModel details=new BookEventModel();
            foreach(Event a in allbooks)
            {
                if(a.EventId==Id)
                {
                    details.UserId = a.UserId;
                    details.Type = a.Type;
                    details.Title = a.Title;
                        details.StartTime = a.StartTime;
                    details.OtherDetails = a.OtherDetails;
                    details.Location = a.Location;
                    details.InviteByEmail = a.InviteByEmail;
                    details.EventId = a.EventId;
                    details.Description = a.Description;
                    details.Date = a.Date;
                    details.Count = a.Count;
                    details.CommentAdded = a.CommentAdded;
                    details.Duration = a.Duration;
                }
            }
            return details;
        }






        public async Task<int> register(RegisterModel registerModel)
        {
            var NewRegister = new Register()
            {
                Email = registerModel.Email,
                FullName = registerModel.FullName,
                Password = registerModel.Password,
                ID = registerModel.ID
            };
            var AllUser = _Context.Register.Where(x=>x.Email.Equals(NewRegister.Email)).FirstOrDefault();
            if(AllUser!=null)
            {
                return 0;
            }

            
                await _Context.Register.AddAsync(NewRegister);
            await _Context.SaveChangesAsync();
            return NewRegister.ID;
        }


        public  string LogIn(LogInModel logInModel)
        {

           
            var AllUser = _Context.Register.Where(x => x.Email.Equals(logInModel.Email)).FirstOrDefault();
            if (AllUser != null)
            {
                var Pass= _Context.Register.Where(x => x.Password.Equals(logInModel.Password)).FirstOrDefault();
                if(Pass!=null)
                {
                   
                    return "Successful Log In";
                }
                else
                {
                    return "PassWord Is Incorrect";
                }
            }
            return "User Does Not Exist";


            
        }


    }
}
