Shader "Custom/HackManC1/4_Blinnphong"
{
    Properties
    {
        _Color("Color", Color) = (1, 1, 1, 1)
        _SpecColor("Specular Color", Color) = (1, 1, 1, 1)
        _SpecularRange("Specular Range", Range(0, 1)) = 0.0
        _SpecularIntensity("Specular Intensity", Range(0, 1)) = 0.0
    }
    
    Subshader
    {
        CGPROGRAM
        #pragma surface surf BlinnPhong
        
        struct Input
        {
            float3 uv_MainTex;
        };
        
        float4 _Color;
        //float4 _SpecColor;
        half _SpecularRange;
        fixed _SpecularIntensity;
        
        void surf(Input IN, inout SurfaceOutput o)
        {
            o.Albedo = _Color.rgb;
            o.Specular = _SpecColor * _SpecularRange;
            o.Gloss = _SpecularIntensity;
        }
        
        ENDCG
    }
    
    Fallback "Diffuse"
}
