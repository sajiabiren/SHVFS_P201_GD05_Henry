Shader "Custom/HackManC1/3_NormalMap"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white"{}
        _NormalTex ("Normal Map", 2D) = "bump"{}
        // Add a slider called Normal Intensity, that allows us to increase or decrease how much the normal map affects the look of our object
        _NormalTexRange ("Normal Map Range", Range(0, 5)) = 0.5
    }
    Subshader
    {
        CGPROGRAM
        #pragma surface surf Lambert
        
        struct Input
        {
            float2 uv_MainTex;
            float2 uv_NormalTex;
        };
        
        sampler2D _MainTex;
        sampler2D _NormalTex;
        half _NormalTexRange;
        
        void surf(Input IN, inout SurfaceOutput o)
        {
            o.Albedo = (tex2D(_MainTex, IN.uv_MainTex)).rgb;
            o.Normal = UnpackNormal(tex2D(_NormalTex, IN.uv_NormalTex));
            o.Normal *= float3(_NormalTexRange, _NormalTexRange, 1);
        }
        ENDCG
    }
    Fallback "Diffuse"
}
