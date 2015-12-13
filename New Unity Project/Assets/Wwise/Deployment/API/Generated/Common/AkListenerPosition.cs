#if ! (UNITY_DASHBOARD_WIDGET || UNITY_WEBPLAYER || UNITY_WII || UNITY_NACL || UNITY_FLASH || UNITY_BLACKBERRY) // Disable under unsupported platforms.
/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 2.0.11
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */


using System;
using System.Runtime.InteropServices;

public class AkListenerPosition : IDisposable {
  private IntPtr swigCPtr;
  protected bool swigCMemOwn;

  internal AkListenerPosition(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = cPtr;
  }

  internal static IntPtr getCPtr(AkListenerPosition obj) {
    return (obj == null) ? IntPtr.Zero : obj.swigCPtr;
  }

  ~AkListenerPosition() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          AkSoundEnginePINVOKE.CSharp_delete_AkListenerPosition(swigCPtr);
        }
        swigCPtr = IntPtr.Zero;
      }
      GC.SuppressFinalize(this);
    }
  }

  public AkVector OrientationFront {
    set {
      AkSoundEnginePINVOKE.CSharp_AkListenerPosition_OrientationFront_set(swigCPtr, AkVector.getCPtr(value));
    } 
    get {
      IntPtr cPtr = AkSoundEnginePINVOKE.CSharp_AkListenerPosition_OrientationFront_get(swigCPtr);
      AkVector ret = (cPtr == IntPtr.Zero) ? null : new AkVector(cPtr, false);
      return ret;
    } 
  }

  public AkVector OrientationTop {
    set {
      AkSoundEnginePINVOKE.CSharp_AkListenerPosition_OrientationTop_set(swigCPtr, AkVector.getCPtr(value));
    } 
    get {
      IntPtr cPtr = AkSoundEnginePINVOKE.CSharp_AkListenerPosition_OrientationTop_get(swigCPtr);
      AkVector ret = (cPtr == IntPtr.Zero) ? null : new AkVector(cPtr, false);
      return ret;
    } 
  }

  public AkVector Position {
    set {
      AkSoundEnginePINVOKE.CSharp_AkListenerPosition_Position_set(swigCPtr, AkVector.getCPtr(value));
    } 
    get {
      IntPtr cPtr = AkSoundEnginePINVOKE.CSharp_AkListenerPosition_Position_get(swigCPtr);
      AkVector ret = (cPtr == IntPtr.Zero) ? null : new AkVector(cPtr, false);
      return ret;
    } 
  }

  public AkListenerPosition() : this(AkSoundEnginePINVOKE.CSharp_new_AkListenerPosition(), true) {

  }

}
#endif // #if ! (UNITY_DASHBOARD_WIDGET || UNITY_WEBPLAYER || UNITY_WII || UNITY_NACL || UNITY_FLASH || UNITY_BLACKBERRY) // Disable under unsupported platforms.