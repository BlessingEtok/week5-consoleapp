using System;
using System.Collections.Generic;
using System.Text;
using Week5.Models;

namespace Week5.Utility
{
  public interface  IInput
    {
        User GetUserInput();
        string GetUserId();

    }
}
