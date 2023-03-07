using RemburshmentAPI.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RemburshmentAPI.Repository
{
    public class SignUpRepository
    {
        private readonly RemContext _Context = null;
        public SignUpRepository(RemContext context)
        {
            _Context = context;
        }


        public async Task<int> register(SignUp registerModel) 
        {
            var AllUser = _Context.SignUp.Where(x => x.Email.Equals(registerModel.Email)).FirstOrDefault();
            if (AllUser != null)
                return 0;
            await _Context.SignUp.AddAsync(registerModel);
            await _Context.SaveChangesAsync();
            return registerModel.ID;
        }
    }
}
