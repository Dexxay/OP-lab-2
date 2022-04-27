using System;
using System.Collections.Generic;

namespace Lab1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            const string filePath = "conversations.bat";
            bool appendOrNot = Operations.ChooseAppendOrNot(filePath);
            List<CallInfo> callList = Operations.InputInfo();
            Operations.SaveInfo(filePath, callList, appendOrNot);

            List<CallInfo> newCallList = Operations.ReadInfo(filePath);
            Operations.ShowInfo(newCallList);

            newCallList = Operations.DeleteShortest(newCallList);
            Operations.SaveInfo(filePath, newCallList, false);

            List <CallInfo>finalCallList = Operations.ReadInfo(filePath);
            Operations.ShowInfo(finalCallList);
        }
    }
}
