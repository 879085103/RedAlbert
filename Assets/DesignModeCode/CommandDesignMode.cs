using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class CommandDesignMode:MonoBehaviour
{
    void Start()
    {
        DMInvoker invoker = new DMInvoker();
        DMReceiver1 receiver1 = new DMReceiver1();
        ConcreateCommand1 command = new ConcreateCommand1(receiver1);

        invoker.AddCommand(command);
        invoker.InvokeCommand();
    }
}

public class DMReceiver1
{
    public void Action()
    {
        Debug.Log("Receiver1执行了命令");
    }

}

public interface ICommand
{
    void Execute();
}

public class ConcreateCommand1:ICommand
{
    private DMReceiver1 mReceiver;
    public ConcreateCommand1(DMReceiver1 receiver)
    {
        mReceiver = receiver;
    }

    public void Execute()
    {
        mReceiver.Action();
    }
}

public class DMInvoker
{
    private List<ICommand> commands = new List<ICommand>();

    public void AddCommand(ICommand cmd)
    {
        commands.Add(cmd);
    }
    public void InvokeCommand()
    {
        foreach(ICommand cmd in commands)
        {
            cmd.Execute();
        }
        commands.Clear();
    }
}





