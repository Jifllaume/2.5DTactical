Shader "Hidden/SpriteOutline"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_Color("Tint", Color) = (1,1,1,1)
		// Add values to determine if outlining is enabled and outline color.
		[PerRendererData] _Outline("Outline", Float) = 0
		[PerRendererData] _OutlineColor("Outline Color", Color) = (1,1,1,1)
    }
    SubShader
    {
		Tags
		{
			"Queue" = "Transparent"
			"RenderType" = "Transparent"
			"PreviewType" = "Plane"
			"CanUseSpriteAtlas" = "True"
		}
        // No culling or depth
        Cull Off ZWrite Off ZTest Always
		Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
				float4 color : COLOR;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
				fixed4 color : COLOR;
            };

			fixed4 _Color;
			float _Outline;
			fixed4 _OutlineColor;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
				o.color = v.color;
                return o;
            }

            sampler2D _MainTex;
			float4 _MainTex_TexelSize;

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
				//if (_Outline > 0 && col.a != 0)
				//{
				//	// Get the neighbouring four pixels.
				//	fixed4 pixelUp = tex2D(_MainTex, i.uv + fixed2(0, _MainTex_TexelSize.y));
				//	fixed4 pixelDown = tex2D(_MainTex, i.uv - fixed2(0, _MainTex_TexelSize.y));
				//	fixed4 pixelRight = tex2D(_MainTex, i.uv + fixed2(_MainTex_TexelSize.x, 0));
				//	fixed4 pixelLeft = tex2D(_MainTex, i.uv - fixed2(_MainTex_TexelSize.x, 0));

				//	// If one of the neighbouring pixels is invisible, we render an outline.
				//	if (pixelUp.a * pixelDown.a * pixelRight.a * pixelLeft.a == 0) 
				//	{
				//		col.rgba = fixed4(1, 1, 1, 1) * _OutlineColor;
				//	}
				//}
				if (_Outline > 0 && col.a == 0)
				{
					// Get the neighbouring four pixels.
					fixed4 pixelUp = tex2D(_MainTex, i.uv + fixed2(0, _MainTex_TexelSize.y));
					fixed4 pixelDown = tex2D(_MainTex, i.uv - fixed2(0, _MainTex_TexelSize.y));
					fixed4 pixelRight = tex2D(_MainTex, i.uv + fixed2(_MainTex_TexelSize.x, 0));
					fixed4 pixelLeft = tex2D(_MainTex, i.uv - fixed2(_MainTex_TexelSize.x, 0));

					// If one of the neighbouring pixels is invisible, we render an outline.
					if (pixelUp.a != 0 || pixelDown.a != 0 || pixelRight.a != 0 || pixelLeft.a != 0)
					{
						col.rgba = fixed4(1, 1, 1, 1) * _OutlineColor;
					}
				}
                return col * _Color;
            }
            ENDCG
        }
    }
}
