// Type: Microsoft.Phone.Shell.ApplicationBar
// Assembly: Microsoft.Phone, Version=7.0.0.0, Culture=neutral, PublicKeyToken=24eec0d8c86cda1e
// Assembly location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\Silverlight\v4.0\Profile\WindowsPhone71\Microsoft.Phone.dll

using Microsoft.Phone;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell.Interop;
using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;

namespace Microsoft.Phone.Shell
{
  /// <summary>
  /// Represents an Application Bar in Windows Phone applications.
  /// </summary>
  [ContentProperty("Buttons")]
  public sealed class ApplicationBar : IApplicationBar
  {
    internal static readonly int MaxIconButtons = 4;
    internal static readonly int MaxMenuItems = 50;
    private const double DefaultOpacity = 1.0;
    private const double AppBarDefaultSize = 72.0;
    private const double AppBarMiniSize = 30.0;
    private bool mIsVisible;
    private double mOpacity;
    private bool mIsMenuEnabled;
    private Color mBackgroundColor;
    private Color mForegroundColor;
    private Microsoft.Phone.Shell.ApplicationBarMode mMode;
    private ApplicationBarItemList<IApplicationBarIconButton> mButtons;
    private ApplicationBarItemList<IApplicationBarMenuItem> mMenuItems;
    private IAppBarInterop mAppBarInterop;
    private AppBarCallbackInfo mCallbacks;
    private EventHandler<ApplicationBarStateChangedEventArgs> StateChanged;

    bool ShouldProcessCommands
    {
      private get
      {
        Application current = Application.Current;
        PhoneApplicationFrame applicationFrame = current != null ? current.RootVisual as PhoneApplicationFrame : (PhoneApplicationFrame) null;
        PhoneApplicationPage phoneApplicationPage = applicationFrame != null ? applicationFrame.Content as PhoneApplicationPage : (PhoneApplicationPage) null;
        bool flag = phoneApplicationPage != null && phoneApplicationPage.NavigationService.IsBackground;
        if (phoneApplicationPage != null && phoneApplicationPage.ApplicationBar == this && !applicationFrame.NavigationService.IsNavigationInProgress)
          return !flag;
        else
          return false;
      }
    }

    /// <summary>
    /// Gets or sets a value that indicates whether the Application Bar is visible.
    /// </summary>
    /// 
    /// <returns>
    /// true if the Application Bar is visible; otherwise, false.
    /// </returns>
    public bool IsVisible
    {
      get
      {
        return this.mIsVisible;
      }
      set
      {
        if (value == this.mIsVisible)
          return;
        this.mIsVisible = value;
        this.mAppBarInterop.SetVisibility(this.mIsVisible);
      }
    }

    /// <summary>
    /// Gets or sets the opacity of the Application Bar.
    /// </summary>
    /// 
    /// <returns>
    /// The opacity of the Application Bar.
    /// </returns>
    public double Opacity
    {
      get
      {
        return this.mOpacity;
      }
      set
      {
        if (value > 1.0)
          value = 1.0;
        else if (value < 0.0)
          value = 0.0;
        if (value == this.mOpacity)
          return;
        this.mOpacity = value;
        this.mAppBarInterop.SetOpacity(this.mOpacity);
      }
    }

    /// <summary>
    /// Gets or sets a value that indicates whether the user can open the menu.
    /// </summary>
    /// 
    /// <returns>
    /// true if the menu is enabled; otherwise, false.
    /// </returns>
    public bool IsMenuEnabled
    {
      get
      {
        return this.mIsMenuEnabled;
      }
      set
      {
        if (value == this.mIsMenuEnabled)
          return;
        this.mIsMenuEnabled = value;
        this.mAppBarInterop.SetMenuEnabled(this.mIsMenuEnabled);
      }
    }

    /// <summary>
    /// Gets or sets the background color of the Application Bar.
    /// </summary>
    /// 
    /// <returns>
    /// The background color of the Application Bar.
    /// </returns>
    /// <exception cref="T:System.ArgumentNullException">The value to set is null.</exception>
    public Color BackgroundColor
    {
      get
      {
        return this.mBackgroundColor;
      }
      set
      {
        if (value.Equals(this.mBackgroundColor))
          return;
        this.mBackgroundColor = value;
        this.mAppBarInterop.SetBackgroundColor(this.mBackgroundColor);
      }
    }

    /// <summary>
    /// Gets or sets the foreground color of the Application Bar.
    /// </summary>
    /// 
    /// <returns>
    /// The foreground color of the Application Bar.
    /// </returns>
    /// <exception cref="T:System.ArgumentNullException">The value to set is null.</exception>
    public Color ForegroundColor
    {
      get
      {
        return this.mForegroundColor;
      }
      set
      {
        if (value.Equals(this.mForegroundColor))
          return;
        this.mForegroundColor = value;
        this.mAppBarInterop.SetForegroundColor(this.mForegroundColor);
      }
    }

    /// <summary>
    /// Gets or sets the size of the Application Bar.
    /// </summary>
    /// 
    /// <returns>
    /// One of the enumeration values that indicates the size of the Application Bar.
    /// </returns>
    public Microsoft.Phone.Shell.ApplicationBarMode Mode
    {
      get
      {
        return this.mMode;
      }
      set
      {
        if (value.Equals((object) this.mMode))
          return;
        this.mMode = value;
        Microsoft.Phone.Shell.Interop.ApplicationBarMode mode = Microsoft.Phone.Shell.Interop.ApplicationBarMode.Default;
        if (value == Microsoft.Phone.Shell.ApplicationBarMode.Minimized)
          mode = Microsoft.Phone.Shell.Interop.ApplicationBarMode.Mini;
        this.mAppBarInterop.SetMode(mode);
      }
    }

    /// <summary>
    /// Gets the distance that the Application Bar extends into a page when the <see cref="P:Microsoft.Phone.Shell.ApplicationBar.Mode"/> property is set to <see cref="F:Microsoft.Phone.Shell.ApplicationBarMode.Default"/>.
    /// </summary>
    /// 
    /// <returns>
    /// The distance that the Application Bar extends into a page.
    /// </returns>
    public double DefaultSize
    {
      get
      {
        return 72.0;
      }
    }

    /// <summary>
    /// Gets the distance that the Application Bar extends into a page when the <see cref="P:Microsoft.Phone.Shell.ApplicationBar.Mode"/> property is set to <see cref="F:Microsoft.Phone.Shell.ApplicationBarMode.Minimized"/>.
    /// </summary>
    /// 
    /// <returns>
    /// The distance that the Application Bar extends into a page.
    /// </returns>
    public double MiniSize
    {
      get
      {
        return 30.0;
      }
    }

    /// <summary>
    /// Gets the list of the buttons that appear on the Application Bar.
    /// </summary>
    /// 
    /// <returns>
    /// The Application Bar buttons.
    /// </returns>
    public IList Buttons
    {
      get
      {
        return (IList) this.mButtons;
      }
    }

    /// <summary>
    /// Gets the list of the menu items that appear on the Application Bar.
    /// </summary>
    /// 
    /// <returns>
    /// The list of menu items.
    /// </returns>
    public IList MenuItems
    {
      get
      {
        return (IList) this.mMenuItems;
      }
    }

    internal NativeAppBarInteropWrapper AppBarInterop
    {
      get
      {
        return this.mAppBarInterop as NativeAppBarInteropWrapper;
      }
    }

    /// <summary>
    /// Occurs when the user opens or closes the menu.
    /// </summary>
    public event EventHandler<ApplicationBarStateChangedEventArgs> StateChanged
    {
      [MethodImpl(MethodImplOptions.Synchronized)] add
      {
        this.StateChanged = this.StateChanged + value;
      }
      [MethodImpl(MethodImplOptions.Synchronized)] remove
      {
        this.StateChanged = this.StateChanged - value;
      }
    }

    static ApplicationBar()
    {
    }

    /// <summary>
    /// Creates a new instance of the <see cref="T:Microsoft.Phone.Shell.ApplicationBar"/> class.
    /// </summary>
    public ApplicationBar()
    {
      this.mIsVisible = true;
      this.mOpacity = 1.0;
      this.mIsMenuEnabled = true;
      this.mCallbacks = new AppBarCallbackInfo();
      this.mCallbacks.cmdcallback += new AppBarCallbackInfo.CommandCallback(this.OnCommand);
      this.mCallbacks.onentermenu += new AppBarCallbackInfo.EnterMenuCallback(this.OnEnterMenu);
      this.mCallbacks.onexitmenu += new AppBarCallbackInfo.ExitMenuCallback(this.OnExitMenu);
      this.mAppBarInterop = !ApplicationBar.IsInDesignMode() ? (IAppBarInterop) new NativeAppBarInteropWrapper() : (IAppBarInterop) new DesignAppBarWrapper();
      this.mAppBarInterop.CreateBar(this.mCallbacks);
      this.mButtons = new ApplicationBarItemList<IApplicationBarIconButton>(true);
      this.mButtons.MAX_ITEMS = ApplicationBar.MaxIconButtons;
      IListInterop listInterop = this.mAppBarInterop.GetListInterop();
      listInterop.SetQuirkNoButtonShifting(QuirksMode.ShouldNotDoAppBarButtonShifting());
      this.mMenuItems = new ApplicationBarItemList<IApplicationBarMenuItem>(false);
      this.mMenuItems.MAX_ITEMS = ApplicationBar.MaxMenuItems;
      this.mButtons.AttachToAppBar(listInterop);
      this.mMenuItems.AttachToAppBar(listInterop);
    }

    ~ApplicationBar()
    {
      this.Close();
    }

    private void Close()
    {
      if (this.mButtons != null)
        this.mButtons.DetachFromAppBar();
      if (this.mMenuItems == null)
        return;
      this.mMenuItems.DetachFromAppBar();
    }

    private static bool IsInDesignMode()
    {
      if (Application.Current != null && Application.Current.GetType() != typeof (Application))
        return DesignerProperties.IsInDesignTool;
      else
        return true;
    }

    internal void OnCommand(uint idCommand)
    {
      if (!this.ShouldProcessCommands)
        return;
      int id = (int) idCommand;
      ApplicationBarItemContainer itemById1 = this.mButtons.GetItemById(id);
      if (itemById1 != null)
      {
        itemById1.ClickEvent();
      }
      else
      {
        ApplicationBarItemContainer itemById2 = this.mMenuItems.GetItemById(id);
        if (itemById2 == null)
          return;
        itemById2.ClickEvent();
      }
    }

    internal void OnEnterMenu()
    {
      if (!Deployment.Current.Dispatcher.CheckAccess())
      {
        Deployment.Current.Dispatcher.BeginInvoke((Action) (() => this.OnEnterMenu()));
      }
      else
      {
        EventHandler<ApplicationBarStateChangedEventArgs> eventHandler = this.StateChanged;
        if (eventHandler == null)
          return;
        eventHandler((object) this, new ApplicationBarStateChangedEventArgs(true));
      }
    }

    internal void OnExitMenu()
    {
      if (!Deployment.Current.Dispatcher.CheckAccess())
      {
        Deployment.Current.Dispatcher.BeginInvoke((Action) (() => this.OnExitMenu()));
      }
      else
      {
        EventHandler<ApplicationBarStateChangedEventArgs> eventHandler = this.StateChanged;
        if (eventHandler == null)
          return;
        eventHandler((object) this, new ApplicationBarStateChangedEventArgs(false));
      }
    }
  }
}
