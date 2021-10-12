using System;
using System.Collections.Generic;
namespace BusinessLogic
{
    public interface IBL
    {
        List<Object> GetAll();
        Object Add(Object o);
    }
}