Shader "Custom/Ground" 
{
	Properties 
	{				
		_MainTex ("Albedo", 2D) = "white" {}		
		_Lava ("Lava", 2D) = "white" {}
		_Normal ("Normal",2D) = "bump" {}
		_HeightMap("HeightMap",2D) = "black" {}
		_Emissive("Emissive", 2D) = "white" {}
		_Slider("Slider", Range(0,10)) = 0.0
		_Tilling("Tilling", Range(0,20)) = 5
		_Speed("Speed", Range(0,1)) = .5
	}
	
	SubShader 
	{		
		CGPROGRAM		
		#pragma surface surf Lambert vertex:vert

		sampler2D _MainTex, _Lava,_Normal,_HeightMap,_Emissive;
		float _Slider, _Tilling, _Speed;
		
		struct Input 
		{
			float2 uv_MainTex;
		};

		void vert(inout appdata_full v){
			//v.vertex tex2Dlod(nameexture, ) _Time.w 

			v.vertex.y += (tex2Dlod(_HeightMap,  v.texcoord).r * _Slider);
		}

		void surf (Input IN, inout SurfaceOutput o) 
		{		
			fixed emission= tex2D(_Emissive,IN.uv_MainTex).r;
			o.Albedo = (1- emission) * tex2D(_MainTex, IN.uv_MainTex).rgb;
			o.Emission =(emission) * tex2D(_Lava,IN.uv_MainTex * float2(_Tilling,_Tilling/2) +float2(_Time.x *0.5,0.0)*_Speed ).rgb;
			o.Normal = UnpackNormal(tex2D(_Normal,IN.uv_MainTex));
		}
		
		ENDCG
	}
	
	FallBack "Diffuse"
}
