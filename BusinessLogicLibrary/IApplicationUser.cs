using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogicLibrary
{
    public interface IApplicationUser
    {
        void UpdateContactInformation();

        bool UpdatePassword();


    }
}
