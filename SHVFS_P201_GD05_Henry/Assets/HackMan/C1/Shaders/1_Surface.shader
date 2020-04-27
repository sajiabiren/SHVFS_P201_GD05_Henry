Shader "Custom/HackManC1/1_Surface"
{
    Properties
    {
        _Color ("color", color) = (1, 1, 1, 1)
    }
    SubShader
    {
        CGPROGRAM
        #pragma surface surf Lambert
        // pragma is a compllier directive
        
        struct Input
        {
            // Needs at least one member...
            float2 uv_MainTex;
        };
        
        fixed4 _Color;
        
        void surf(Input IN, inout SurfaceOutput o)
        {
            o.Albedo = _Color.rgb;
        }
        
        ENDCG
    }
    FallBack "Diffuse"
}
