// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Psychodilias/hallucination"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_frequency ("frequency", Float) = 1
		_amplitude ("amplitude", Float) = 1
		_speed ("speed", Float) = 1
		_yPercentage ("yPercentage", Float) = 1

	}

	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

				struct appdata
				{
					float4 vertex : POSITION;
					float2 uv : TEXCOORD0;
				};

				struct v2f
				{
					float2 uv : TEXCOORD0;
					float4 vertex : SV_POSITION;
				};

				v2f vert (appdata v)
				{
					v2f o;
					o.vertex = UnityObjectToClipPos (v.vertex);
					o.uv = v.uv;
					return o;
				}

				sampler2D _MainTex;
				float _frequency;
				float _speed;
				float _amplitude;
				float _yPercentage;

				fixed4 frag (v2f i) : SV_Target
				{				
					fixed4 col;
					float2 hallucination = float2( 0 , 0 );

					//Has waviness percentage

					//Has hallucination percentage

					//Applies wave on image
					if (i.uv.y > _yPercentage)
					{
						hallucination = float2( 0 , sin (i.uv.x * _frequency + _Time[1] * _speed)  * _amplitude );
					}

					col = tex2D (_MainTex , i.uv + hallucination);

					//Inverts color 
					if (i.uv.y > _yPercentage)
					{
						col = 1 - col;
					}
				
					return col;
				}

			ENDCG
		}
	}
}