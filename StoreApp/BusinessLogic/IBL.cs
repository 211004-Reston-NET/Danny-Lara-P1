using System;
using System.Collections.Generic;
namespace BusinessLogic
{
    public interface IBL
    {
        List<Object> GetAll();
        Object Add(object o);
        void Update(object o);
    }
}