Shader "Custom/HackManC1/1_SurfaceTexture"
{
    Properties
    {
        _Color ("color", color) = (1, 1, 1, 1)
        _MainTex ("Texture", 2D) = "white"{}
        _TextRange ("Texture Range", Range(0, 5)) = 0.5
    }
    SubShader
    {
        CGPROGRAM
        #pragma surface surf Lambert
        
        struct Input
        {
            // Needs at least one member...
            float2 uv_MainTex;
        };
        
// Packed array
        fixed4 _Color; //float 32bits half 16bits fixed 11bits
        sampler2D _MainTex;
        float _TextRange;        
        
        void surf(Input IN, inout SurfaceOutput o)
        {
            o.Albedo = (tex2D(_MainTex, IN.uv_MainTex) * _TextRange * _Color).rgb;
        }
        
        ENDCG
    }
    FallBack "Diffuse"
}
