using UnityEngine;
using Leap.Unity;
using Leap;
using UnityEngine.UI;

public class LeapImageController : MonoBehaviour
{
    private Controller _controller;
    private LeapServiceProvider _provider;
    Texture2D tex2D;
    public RenderTexture renTex;

    [SerializeField] Text ErrorBox;

    private void Awake()
    {
        _provider = FindObjectOfType<LeapServiceProvider>();
        if (_provider != null) _controller = _provider.GetLeapController();
        else
        {
            ErrorBox.text += "provider not ready\n";
        }
    }

    void Start()
    {
        if (_controller != null)
            _controller.ImageReady += onImageReady;
        else
        {
            ErrorBox.text += "controller not ready\n";
        }

        //Debug.LogWarning("Warning - Leap controller is null");
    }

    private void onImageReady(object sender, Leap.ImageEventArgs args)
    {
        if (tex2D == null)
        {
            tex2D = new Texture2D(
                args.image.Width, args.image.Height, TextureFormat.R8, false);
        }

        tex2D.LoadRawTextureData(args.image.Data(Leap.Image.CameraType.LEFT));

        tex2D.Apply();

        Graphics.Blit(tex2D, renTex);

        #region Finger Tip Search (Disposal)
        //int targetWidth = 256;
        //int targetHeight = 256;
        //float cameraXOffset = 20; //millimeters
        //foreach (Hand hand in _controller.Frame().Hands)
        //{
        //    foreach (Finger finger in hand.Fingers)
        //    {
        //        Vector tip = finger.TipPosition;
        //        float hSlope = -(tip.x - cameraXOffset) / tip.y; //For left camera
        //        float vSlope = tip.z / tip.y;

        //        Vector ray = new Vector(
        //            hSlope * args.image.RayScaleX(Leap.Image.CameraType.LEFT)
        //            + args.image.RayOffsetX(Leap.Image.CameraType.LEFT),
        //                             vSlope * args.image.RayScaleY(Leap.Image.CameraType.LEFT)
        //                             + args.image.RayOffsetY(Leap.Image.CameraType.LEFT), 0);

        //        //Pixel coordinates from [0..1] to [0..width/height]
        //        //Vector pixel = new Vector(ray.x * targetWidth, ray.y * targetHeight, 0);
        //        Vector pixel = new Vector(ray.x, ray.y, 0);
        //        Vector4 newVec = new Vector4(pixel.x, pixel.y, pixel.z, 0);
        //        rawImage.material.SetVector("_TipPos", newVec);
        //    }
        //}

        //float cameraOffset = 20; //x-axis offset in millimeters
        //foreach (Hand hand in _controller.Frame().Hands)
        //{
        //    foreach (Finger finger in hand.Fingers)
        //    {
        //        Vector tip = finger.TipPosition;
        //        float hSlope = -(tip.x - cameraOffset) / tip.y; //For left camera
        //        float vSlope = tip.z / tip.y;
        //        Vector pixel = args.image.RectilinearToPixel(Leap.Image.CameraType.LEFT, new Vector(hSlope, vSlope, 0));
        //        //Draw tip at pixel

        //        Vector4 newVec = new Vector4(pixel.x, pixel.y, pixel.z, 0);
        //        rawImage.material.SetVector("_TipPos", newVec);
        //    }
        //}
        #endregion
    }
}
