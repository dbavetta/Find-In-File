using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FindInFile_Wpf.Utilities
{
    public class ThreadSafeOperations
    {
        ///// <summary>
        ///// Use whenever actions caused on a form control may cause a worker thread and the UI thread to compete for that same control. 
        ///// ~~ Always use if the action is is nested or called anywhere in the Parallel.Foreach ~~
        ///// </summary>
        ///// <param name="control"> Windows form control </param>
        ///// <param name="action"> Action/s to be executed </param>
        ///// Usage: ThreadSafeActionBlock(control, () => { Action_Logic_Here; } || () => MethodName() }
        //public static void ActionBlock(Control control, Action action)
        //{
        //    if (control.InvokeRequired)
        //    {
        //        control.BeginInvoke(new MethodInvoker(
        //            delegate
        //            {
        //                action();
        //            })
        //        );
        //    }
        //}

        ///// <summary>
        ///// Use whenever actions caused on a form control may cause a worker thread and the UI thread to compete for that same control. 
        ///// ~~ Always use if the action is is nested or called anywhere in the Parallel.Foreach ~~
        ///// </summary>
        ///// <param name="control"> Windows form control </param>
        ///// <param name="action"> Action/s to be executed </param>
        ///// <param name="input"> Parameter to be used within the action block</param>
        ///// Usage: ThreadSafeActionBlock(control, () => { Action_Logic_Here(); } || () => MethodName() }
        //public static void ActionBlock(Control control, Action<object> action, object input)
        //{
        //    if (control.InvokeRequired)
        //    {
        //        control.BeginInvoke(new MethodInvoker(
        //            delegate
        //            {
        //                action(input);
        //            })
        //        );
        //    }
        //}

        ///// <summary>
        ///// Use whenever actions caused on a form control may cause a worker thread and the UI thread to compete for that same control. 
        ///// ~~ Always use if the action is is nested or called anywhere in the Parallel.Foreach ~~
        ///// </summary>
        ///// <param name="control"> Windows form control </param>
        ///// <param name="action"> Action/s to be executed </param>
        ///// <param name="input"> Parameter to be used within the action block</param>
        ///// Usage: var result = ThreadSafeActionBlock(control, () => { Action_Logic_Here; More_Logic; }
        //public static object FunctionBlock(Control control, Func<object, object> func, object input)
        //{
        //    object result = null;
        //    if (control.InvokeRequired)
        //    {
        //        control.BeginInvoke(new MethodInvoker(
        //            delegate
        //            {
        //                result = func(input);

        //            })
        //        );
        //    }
        //    return result;
        //}
    }
}
