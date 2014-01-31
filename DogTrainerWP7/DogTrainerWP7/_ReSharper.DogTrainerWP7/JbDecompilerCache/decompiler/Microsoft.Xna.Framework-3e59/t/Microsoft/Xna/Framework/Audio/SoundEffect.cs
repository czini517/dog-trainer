// Type: Microsoft.Xna.Framework.Audio.SoundEffect
// Assembly: Microsoft.Xna.Framework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=842cf8be1de50553
// Assembly location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\Silverlight\v4.0\Profile\WindowsPhone71\Microsoft.Xna.Framework.dll

using System;
using System.IO;
using System.Security;

namespace Microsoft.Xna.Framework.Audio
{
  /// <summary>
  /// Reference page contains links to related code samples.
  /// </summary>
  public sealed class SoundEffect : IDisposable
  {
    /// <summary>
    /// Gets or sets a value that adjusts the effect of distance calculations on the sound (emitter).
    /// </summary>
    public static float DistanceScale
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
    /// Gets or sets a value that adjusts the effect of doppler calculations on the sound (emitter).
    /// </summary>
    public static float DopplerScale
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
    /// Gets the duration of the SoundEffect.
    /// </summary>
    public TimeSpan Duration
    {
      get
      {
        // ISSUE: unable to decompile the method.
      }
    }

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
    /// Gets or sets the master volume that affects all SoundEffectInstance sounds.
    /// </summary>
    public static float MasterVolume
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
    /// Gets or sets the asset name of the SoundEffect.
    /// </summary>
    public string Name
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
    /// Returns the speed of sound: 343.5 meters per second.
    /// </summary>
    public static float SpeedOfSound
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
    /// Initializes a new instance of SoundEffect based on an audio buffer, sample rate, and number of audio channels. Reference page contains links to related conceptual articles.
    /// </summary>
    /// <param name="buffer">Buffer that contains the audio data. The audio format must be PCM wave data.</param><param name="sampleRate">Sample rate, in Hertz (Hz), of audio data.</param><param name="channels">Number of channels (mono or stereo) of audio data.</param>
    public SoundEffect(byte[] buffer, int sampleRate, AudioChannels channels)
    {
    }

    /// <summary>
    /// Initializes a new instance of SoundEffect with specified parameters such as audio sample rate, channels, looping criteria, and a buffer to hold the audio. Reference page contains links to related conceptual articles.
    /// </summary>
    /// <param name="buffer">Buffer that contains the audio data. The audio format must be PCM wave data.</param><param name="offset">Offset, in bytes, to the starting position of the audio data.</param><param name="count">Amount, in bytes, of audio data.</param><param name="sampleRate">Sample rate, in Hertz (Hz), of audio data.</param><param name="channels">Number of channels (mono or stereo) of audio data.</param><param name="loopStart">Loop start in samples.</param><param name="loopLength">Loop length in samples.</param>
    public SoundEffect(byte[] buffer, int offset, int count, int sampleRate, AudioChannels channels, int loopStart, int loopLength)
    {
    }

    ~SoundEffect()
    {
    }

    /// <summary>
    /// Creates a SoundEffect object based on the specified data stream.
    /// </summary>
    /// <param name="stream">Stream object that contains the data for this SoundEffect object.</param>
    public static SoundEffect FromStream(Stream stream)
    {
      // ISSUE: unable to decompile the method.
    }

    /// <summary>
    /// Releases the resources used by the SoundEffect.
    /// </summary>
    public void Dispose()
    {
    }

    /// <summary>
    /// Creates a new SoundEffectInstance for this SoundEffect. Reference page contains links to related code samples.
    /// </summary>
    public SoundEffectInstance CreateInstance()
    {
      // ISSUE: unable to decompile the method.
    }

    /// <summary>
    /// Plays a sound. Reference page contains links to related code samples.
    /// </summary>
    public bool Play()
    {
      // ISSUE: unable to decompile the method.
    }

    /// <summary>
    /// Plays a sound based on specified volume, pitch, and panning. Reference page contains links to related code samples.
    /// </summary>
    /// <param name="volume">Volume, ranging from 0.0f (silence) to 1.0f (full volume). 1.0f is full volume relative to SoundEffect.MasterVolume.</param><param name="pitch">Pitch adjustment, ranging from -1.0f (down one octave) to 1.0f (up one octave). 0.0f is unity (normal) pitch.</param><param name="pan">Panning, ranging from -1.0f (full left) to 1.0f (full right). 0.0f is centered.</param>
    public bool Play(float volume, float pitch, float pan)
    {
      // ISSUE: unable to decompile the method.
    }

    /// <summary>
    /// Returns the size of the audio sample based on duration, sample rate, and audio channels.
    /// </summary>
    /// <param name="duration">TimeSpan object that contains the sample duration.</param><param name="sampleRate">Sample rate, in Hertz (Hz), of audio content. The sampleRate parameter must be between 8,000 Hz and 48,000 Hz.</param><param name="channels">Number of channels in the audio data.</param>
    public static int GetSampleSizeInBytes(TimeSpan duration, int sampleRate, AudioChannels channels)
    {
      // ISSUE: unable to decompile the method.
    }

    /// <summary>
    /// Returns the sample duration based on the specified sample size and sample rate.
    /// </summary>
    /// <param name="sizeInBytes">Size, in bytes, of audio data.</param><param name="sampleRate">Sample rate, in Hertz (Hz), of audio content. The sampleRate must be between 8000 Hz and 48000 Hz.</param><param name="channels">Number of channels in the audio data.</param>
    public static TimeSpan GetSampleDuration(int sizeInBytes, int sampleRate, AudioChannels channels)
    {
      // ISSUE: unable to decompile the method.
    }
  }
}
