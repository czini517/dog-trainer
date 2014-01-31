// Type: Caliburn.Micro.PhoneBootstrapper
// Assembly: Caliburn.Micro, Version=1.3.1.0, Culture=neutral, PublicKeyToken=null
// Assembly location: D:\Sajat projektek\DogTrainerWP7\DogTrainerWP7\packages\Caliburn.Micro.1.3.1\lib\sl4-windowsphone71\Caliburn.Micro.dll

using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Windows;
using System.Windows.Navigation;

namespace Caliburn.Micro
{
  /// <summary>
  /// A custom bootstrapper designed to setup phone applications.
  /// 
  /// </summary>
  public class PhoneBootstrapper : Bootstrapper
  {
    private bool phoneApplicationInitialized;
    private PhoneApplicationService phoneService;

    /// <summary>
    /// The root frame used for navigation.
    /// 
    /// </summary>
    public PhoneApplicationFrame RootFrame { get; private set; }

    public PhoneBootstrapper()
      : base(true)
    {
    }

    /// <summary>
    /// Provides an opportunity to hook into the application object.
    /// 
    /// </summary>
    protected override void PrepareApplication()
    {
      base.PrepareApplication();
      this.phoneService = new PhoneApplicationService();
      this.phoneService.Activated += new EventHandler<ActivatedEventArgs>(this.OnActivate);
      this.phoneService.Deactivated += new EventHandler<DeactivatedEventArgs>(this.OnDeactivate);
      this.phoneService.Launching += new EventHandler<LaunchingEventArgs>(this.OnLaunch);
      this.phoneService.Closing += new EventHandler<ClosingEventArgs>(this.OnClose);
      this.Application.ApplicationLifetimeObjects.Add((object) this.phoneService);
      if (this.phoneApplicationInitialized)
        return;
      this.RootFrame = this.CreatePhoneApplicationFrame();
      this.RootFrame.Navigated += new NavigatedEventHandler(this.OnNavigated);
      this.phoneApplicationInitialized = true;
    }

    private void OnNavigated(object sender, NavigationEventArgs e)
    {
      if (this.Application.RootVisual == this.RootFrame)
        return;
      this.Application.RootVisual = (UIElement) this.RootFrame;
    }

    /// <summary>
    /// Creates the root frame used by the application.
    /// 
    /// </summary>
    /// 
    /// <returns>
    /// The frame.
    /// </returns>
    protected virtual PhoneApplicationFrame CreatePhoneApplicationFrame()
    {
      return new PhoneApplicationFrame();
    }

    /// <summary>
    /// Occurs when a fresh instance of the application is launching.
    /// 
    /// </summary>
    protected virtual void OnLaunch(object sender, LaunchingEventArgs e)
    {
    }

    /// <summary>
    /// Occurs when a previously tombstoned or paused application is resurrected/resumed.
    /// 
    /// </summary>
    protected virtual void OnActivate(object sender, ActivatedEventArgs e)
    {
    }

    /// <summary>
    /// Occurs when the application is being tombstoned or paused.
    /// 
    /// </summary>
    protected virtual void OnDeactivate(object sender, DeactivatedEventArgs e)
    {
    }

    /// <summary>
    /// Occurs when the application is closing.
    /// 
    /// </summary>
    protected virtual void OnClose(object sender, ClosingEventArgs e)
    {
    }
  }
}
