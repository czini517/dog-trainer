// Type: Caliburn.Micro.Bootstrapper
// Assembly: Caliburn.Micro, Version=1.3.1.0, Culture=neutral, PublicKeyToken=null
// Assembly location: D:\Sajat projektek\DogTrainerWP7\DogTrainerWP7\packages\Caliburn.Micro.1.3.1\lib\sl4-windowsphone71\Caliburn.Micro.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace Caliburn.Micro
{
  /// <summary>
  /// Instantiate this class in order to configure the framework.
  /// 
  /// </summary>
  public class Bootstrapper
  {
    private readonly bool useApplication;
    private readonly bool isInitialized;

    /// <summary>
    /// The application.
    /// 
    /// </summary>
    protected Application Application { get; set; }

    /// <summary>
    /// Creates an instance of the bootstrapper.
    /// 
    /// </summary>
    /// <param name="useApplication">Set this to false when hosting Caliburn.Micro inside and Office or WinForms application. The default is true.</param>
    public Bootstrapper(bool useApplication = true)
    {
      this.useApplication = useApplication;
      if (this.isInitialized)
        return;
      this.isInitialized = true;
      if (Execute.InDesignMode)
      {
        try
        {
          this.StartDesignTime();
        }
        catch
        {
          this.isInitialized = false;
        }
      }
      else
        this.StartRuntime();
    }

    /// <summary>
    /// Called by the bootstrapper's constructor at design time to start the framework.
    /// 
    /// </summary>
    protected virtual void StartDesignTime()
    {
      AssemblySource.Instance.AddRange(this.SelectAssemblies());
      this.Configure();
      IoC.GetInstance = new Func<Type, string, object>(this.GetInstance);
      IoC.GetAllInstances = new Func<Type, IEnumerable<object>>(this.GetAllInstances);
      IoC.BuildUp = new System.Action<object>(this.BuildUp);
    }

    /// <summary>
    /// Called by the bootstrapper's constructor at runtime to start the framework.
    /// 
    /// </summary>
    protected virtual void StartRuntime()
    {
      Execute.InitializeWithDispatcher();
      EventAggregator.DefaultPublicationThreadMarshaller = new System.Action<System.Action>(Execute.OnUIThread);
      AssemblySource.Instance.AddRange(this.SelectAssemblies());
      if (this.useApplication)
      {
        this.Application = Application.Current;
        this.PrepareApplication();
      }
      this.Configure();
      IoC.GetInstance = new Func<Type, string, object>(this.GetInstance);
      IoC.GetAllInstances = new Func<Type, IEnumerable<object>>(this.GetAllInstances);
      IoC.BuildUp = new System.Action<object>(this.BuildUp);
    }

    /// <summary>
    /// Provides an opportunity to hook into the application object.
    /// 
    /// </summary>
    protected virtual void PrepareApplication()
    {
      this.Application.Startup += new StartupEventHandler(this.OnStartup);
      this.Application.UnhandledException += new EventHandler<ApplicationUnhandledExceptionEventArgs>(this.OnUnhandledException);
      this.Application.Exit += new EventHandler(this.OnExit);
    }

    /// <summary>
    /// Override to configure the framework and setup your IoC container.
    /// 
    /// </summary>
    protected virtual void Configure()
    {
    }

    /// <summary>
    /// Override to tell the framework where to find assemblies to inspect for views, etc.
    /// 
    /// </summary>
    /// 
    /// <returns>
    /// A list of assemblies to inspect.
    /// </returns>
    protected virtual IEnumerable<Assembly> SelectAssemblies()
    {
      if (Execute.InDesignMode)
      {
        AppDomain currentDomain = AppDomain.CurrentDomain;
        return (IEnumerable<Assembly>) new Assembly[1]
        {
          Enumerable.FirstOrDefault<Assembly>(Enumerable.Where<Assembly>((IEnumerable<Assembly>) (currentDomain.GetType().GetMethod("GetAssemblies").Invoke((object) currentDomain, (object[]) null) as Assembly[] ?? new Assembly[0]), (Func<Assembly, bool>) (x =>
          {
            if (x.EntryPoint != null)
              return Enumerable.Any<Type>((IEnumerable<Type>) x.GetTypes(), (Func<Type, bool>) (t => t.IsSubclassOf(typeof (Application))));
            else
              return false;
          })))
        };
      }
      else
        return (IEnumerable<Assembly>) new Assembly[1]
        {
          Application.Current.GetType().Assembly
        };
    }

    /// <summary>
    /// Override this to provide an IoC specific implementation.
    /// 
    /// </summary>
    /// <param name="service">The service to locate.</param><param name="key">The key to locate.</param>
    /// <returns>
    /// The located service.
    /// </returns>
    protected virtual object GetInstance(Type service, string key)
    {
      return Activator.CreateInstance(service);
    }

    /// <summary>
    /// Override this to provide an IoC specific implementation
    /// 
    /// </summary>
    /// <param name="service">The service to locate.</param>
    /// <returns>
    /// The located services.
    /// </returns>
    protected virtual IEnumerable<object> GetAllInstances(Type service)
    {
      return (IEnumerable<object>) new object[1]
      {
        Activator.CreateInstance(service)
      };
    }

    /// <summary>
    /// Override this to provide an IoC specific implementation.
    /// 
    /// </summary>
    /// <param name="instance">The instance to perform injection on.</param>
    protected virtual void BuildUp(object instance)
    {
    }

    /// <summary>
    /// Override this to add custom behavior to execute after the application starts.
    /// 
    /// </summary>
    /// <param name="sender">The sender.</param><param name="e">The args.</param>
    protected virtual void OnStartup(object sender, StartupEventArgs e)
    {
    }

    /// <summary>
    /// Override this to add custom behavior on exit.
    /// 
    /// </summary>
    /// <param name="sender">The sender.</param><param name="e">The event args.</param>
    protected virtual void OnExit(object sender, EventArgs e)
    {
    }

    /// <summary>
    /// Override this to add custom behavior for unhandled exceptions.
    /// 
    /// </summary>
    /// <param name="sender">The sender.</param><param name="e">The event args.</param>
    protected virtual void OnUnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
    {
    }
  }
}
