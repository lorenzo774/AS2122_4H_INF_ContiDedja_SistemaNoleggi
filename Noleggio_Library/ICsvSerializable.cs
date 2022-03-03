using System;
using System.Collections.Generic;
using System.Text;

namespace Noleggio_Library
{
    public interface ICsvSerializable
    {
        string CsvFormat();

        ICsvSerializable ObjectFormat(string str);
    }
}