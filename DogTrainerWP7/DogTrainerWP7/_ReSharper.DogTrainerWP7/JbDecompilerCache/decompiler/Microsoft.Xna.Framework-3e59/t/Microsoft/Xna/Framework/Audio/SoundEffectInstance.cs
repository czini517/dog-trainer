// Type: Microsoft.Xna.Framework.Audio.SoundEffectInstance
// Assembly: Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553
// Assembly location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\Silverlight\v4.0\Profile\WindowsPhone71\Microsoft.Xna.Framework.dll

using System;
using System.Security;

namespace Microsoft.Xna.Framework.Audio
{
  /// <summary>
  /// Provides a single playing, paused, or stopped instance of a SoundEffect sound.
  /// </summary>
  public class SoundEffectInstance : IDisposable
  {
    /// <summary>
    /// Gets a value that indicates whether the object is disposed.
    /// </summary>
    public bool IsDisposed
    {
      get
      {
        // ISSUE: unable to decompile the method.
      }
    }

    /// <summary>
    /// Gets a value that indicates whether looping is enabled for the SoundEffectInstance. Reference page contains links to related code samples.
    /// </summary>
    public virtual bool IsLooped
    {
      get
      {
        // ISSUE: unable to decompile the method.
      }
      set
      {
      }
    }

    /// <summary>
    /// Gets or sets the panning for the SoundEffectInstance.
    /// </summary>
    public float Pan
    {
      get
      {
        // ISSUE: unable to decompile the method.
      }
      [SecuritySafeCritical] set
      {
      }
    }

    /// <summary>
    /// Gets or sets the pitch adjustment for the SoundEffectInstance. Reference page contains links to related code samples.
    /// </summary>
    public float Pitch
    {
      get
      {
        // ISSUE: unable to decompile the method.
      }
      [SecuritySafeCritical] set
      {
      }
    }

    /// <summary>
    /// Gets the current state (playing, paused, or stopped) of the SoundEffectInstance.
    /// </summary>
    public SoundState State
    {
      [SecuritySafeCritical] get
      {
        // ISSUE: unable to decompile the method.
      }
    }

    /// <summary>
    /// Gets or sets the volume of the SoundEffectInstance. Reference page contains links to related code samples.
    /// </summary>
    public float Volume
    {
      get
      {
        // ISSUE: unable to decompile the method.
      }
      [SecuritySafeCritical] set
      {
      }
    }

    /// <summary>
    /// Releases unmanaged resources and performs other cleanup operations before the SoundEffectInstance is reclaimed by garbage collection.
    /// </summary>
    ~SoundEffectInstance()
    {
    }

    /// <summary>
    /// Releases unmanaged resources held by this SoundEffectInstance.
    /// </summary>
    public void Dispose()
    {
    }

    /// <summary>
    /// Releases the unmanaged resources held by this SoundEffectInstance, and optionally releases the managed resources.
    /// </summary>
    /// <param name="disposing">Pass true to release both the managed and unmanaged resources for this SoundEffectInstance. Passing false releases only the unmanaged resources.</param>
    protected virtual void Dispose(bool disposing)
    {
    }

    /// <summary>
    /// Plays or resumes a SoundEffectInstance.
    /// </summary>
    [SecuritySafeCritical]
    public virtual void Play()
    {
    }

    /// <summary>
    /// Immediately stops playing a SoundEffectInstance.
    /// </summary>
    public void Stop()
    {
    }

    /// <summary>
    /// Stops playing a SoundEffectInstance, either immediately or as authored.
    /// </summary>
    /// <param name="immediate">Whether to stop playing immediately, or to break out of the loop region and play the release. Specify true to stop playing immediately, or false to break out of the loop region and play the release phase (the remainder of the sound).</param>
    [SecuritySafeCritical]
    public void Stop(bool immediate)
    {
    }

    /// <summary>
    /// Pauses a SoundEffectInstance.
    /// </summary>
    [SecuritySafeCritical]
    public void Pause()
    {
    }

    /// <summary>
    /// Resumes playback for a SoundEffectInstance.
    /// </summary>
    [SecuritySafeCritical]
    public void Resume()
    {
    }

    /// <summary>
    /// Applies 3D positioning to the sound using a single listener. Reference page contains links to related code samples.
    /// </summary>
    /// <param name="listener">Position of the listener.</param><param name="emitter">Position of the emitter.</param>
    public void Apply3D(AudioListener listener, AudioEmitter emitter)
    {
    }

    /// <summary>
    /// Applies 3D position to the sound using multiple listeners. Reference page contains links to related code samples.
    /// </summary>
    /// <param name="listeners">Positions of each listener.</param><param name="emitter">Position of the emitter.</param>
    public void Apply3D(AudioListener[] listeners, AudioEmitter emitter)
    {
    }
  }
}
