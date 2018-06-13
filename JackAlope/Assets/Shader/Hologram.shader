Shader "Custom/Hologram"
{
	Properties
	{

		_MainTex("Albedo", 2D) = "white" {}
	_Noise("Noise", 2D) = "white" {}
	_Lines("Lines", 2D) = "white" {}
	_Color("Hologram Color", Color) = (0,0,1)
		_RimPower("Rim Power", Range(0,6)) = 0.5
		_RimColor("Color", Color) = (1,1,1,1)
	}

		SubShader
	{
		Tags{ "RenderType" = "Transparency" }
		Cull Off

		CGPROGRAM
		#pragma surface surf Standard
		#pragma target 3.0

	sampler2D _MainTex,_Noise,_Lines;
	fixed4 _Color;

	float _RimPower;
	float4 _RimColor;

	struct Input
	{

		float2 uv_MainTex;
		float3 viewDir;
		float3 worldNormal;
	};


	void surf(Input IN, inout SurfaceOutputStandard o)
	{
		fixed4 main = (tex2D(_MainTex, IN.uv_MainTex) +( (tex2D(_Noise, IN.uv_MainTex + float2(_Time.x,0)) + tex2D(_Lines, IN.uv_MainTex + float2(0,_Time.x * 2))) * (tex2D(_MainTex, IN.uv_MainTex).a)) )* _Color;

		if (main.a < 0.1) {
			discard;
		}

		o.Albedo = main;
		float NdotV = 1.0 - saturate(dot(IN.viewDir, IN.worldNormal));
		o.Emission = _RimColor * pow(NdotV, _RimPower);
	}

	ENDCG
	}

		FallBack "Diffuse"
}
