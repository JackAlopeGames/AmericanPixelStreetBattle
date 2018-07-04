Shader "Custom/Rim" 
{
	Properties 
	{				
		_MainTex ("Albedo", 2D) = "white" {}	
		_RimPower("Rim Power", Range(0,6)) = 0.5
		_RimColor("Color", Color) = (1,1,1,1)
	}
	
	SubShader 
	{		
		CGPROGRAM		
		#pragma surface surf Lambert

		sampler2D _MainTex;
		float _RimPower;
		float4 _RimColor;
		
		struct Input 
		{
			float2 uv_MainTex;
			float3 viewDir;
			float3 worldNormal;
		};

		
		void surf (Input IN, inout SurfaceOutput o) 
		{		
			o.Albedo = tex2D(_MainTex,IN.uv_MainTex).rgb; // + _RimColor * pow(normalize(_WorldSpaceCameraPos), _RimPower);
			float NdotV = 1.0 - saturate(dot(IN.viewDir, IN.worldNormal));
			o.Emission = _RimColor * pow(NdotV,_RimPower);
		}
		
		ENDCG
	}
	
	FallBack "Diffuse"
}
