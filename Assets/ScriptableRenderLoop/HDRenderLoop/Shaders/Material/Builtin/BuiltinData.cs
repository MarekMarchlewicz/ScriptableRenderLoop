using UnityEngine;

//-----------------------------------------------------------------------------
// structure definition
//-----------------------------------------------------------------------------
namespace UnityEngine.Experimental.ScriptableRenderLoop
{
    namespace Builtin
    {
        //-----------------------------------------------------------------------------
        // BuiltinData
        // This structure include common data that should be present in all material
        // and are independent from the BSDF parametrization.
        // Note: These parameters can be store in GBuffer if the writer wants
        //-----------------------------------------------------------------------------
        [GenerateHLSL(PackingRules.Exact, false, true, 100)]
        public struct BuiltinData
        {
            [SurfaceDataAttributes("Opacity")]
            public float opacity;

            // These are lighting data.
            // We would prefer to split lighting and material information but for performance reasons,
            // those lighting information are fill
            // at the same time than material information.
            [SurfaceDataAttributes("Bake Diffuse Lighting")]
            public Vector3 bakeDiffuseLighting; // This is the result of sampling lightmap/lightprobe/proxyvolume

            [SurfaceDataAttributes("Emissive Color")]
            public Vector3 emissiveColor;
            [SurfaceDataAttributes("Emissive Intensity")]
            public float emissiveIntensity;

            // These is required for motion blur and temporalAA
            [SurfaceDataAttributes("Velocity")]
            public Vector2 velocity;

            // Distortion
            [SurfaceDataAttributes("Distortion")]
            public Vector2 distortion;
            [SurfaceDataAttributes("Distortion Blur")]
            public float distortionBlur;           // Define the color buffer mipmap level to use
        };
    }
}