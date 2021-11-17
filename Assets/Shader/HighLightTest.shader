Shader "Custom/HighLightTest"
{
    Properties
	{
		_MainTex("Texture(RGB)",2D) = "grey"{}	//主纹理
		_Color("Color",Color) = (0,0,0,0)		//主纹理颜色
		_AtmoColor("Atmosphere Color",Color) = (0,0,0,0)	//光晕颜色
		_Size("Size",Range(0,20)) = 0.1		//光晕范围
		_OutLightPow("Falloff",Range(1,10)) = 5		//光晕系数
		_OutLightStrength("Transparency",Range(5,20)) = 15	//光晕强度
	}
 
		SubShader{
			Pass{
				Name "PlaneBase"
				Tags{"LightMode" = "Always"}
				Cull Back		//剔除背面
				CGPROGRAM
	#pragma vertex vert
	#pragma fragment frag
	#include "UnityCG.cginc"
 
		uniform sampler2D _MainTex;
		uniform float4 _MainTex_ST;
		uniform float4 _Color;
		uniform float4 _AtmoColor;
		uniform float _Size;
		uniform float _OutLightPow;
		uniform float _OutLightStrength;
 
		struct vertexOutput {
			float4 pos : SV_POSITION;
			float3 normal : TEXCOORD0;
			float3 worldvertpos : TEXCOORD1;
			float2 texcoord : TEXCOORD2;
		};
 
		//顶点着色器
		vertexOutput vert(appdata_base v)
		{
			vertexOutput o;
			//顶点位置
			o.pos = UnityObjectToClipPos(v.vertex);
			//法线
			o.normal = v.normal;
			//世界坐标顶点位置
			o.worldvertpos = mul(unity_ObjectToWorld, v.vertex).xyz;
			o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
			return o;
		}
 
		float4 frag(vertexOutput i) : COLOR
		{
			float4 color = tex2D(_MainTex,i.texcoord);
			return color * _Color;
		}
			ENDCG
		}
 
		Pass{
			Name "AtmosphereBase"
			Tags{"LightMode" = "Always"}
			Cull Front
			Blend SrcAlpha One
 
			CGPROGRAM
	#pragma vertex vert
	#pragma fragment frag
	#include "UnityCG.cginc"
 
		uniform float4 _Color;
		uniform float4 _AtmoColor;
		uniform float _Size;
		uniform float _OutLightPow;
		uniform float _OutLightStrength;
 
		struct vertexOutput
		{
			float4 pos : SV_POSITION;
			float3 normal : TEXCOORD0;
			float3 worldvertpos : TEXCOORD1;
		};
 
		vertexOutput vert(appdata_base v) {
			vertexOutput o;
			//顶点位置以法线方向向外延伸
			v.vertex.xyz += v.normal * _Size;
			o.pos = UnityObjectToClipPos(v.vertex);
			o.normal = v.normal;
			o.worldvertpos = mul(unity_ObjectToWorld, v.vertex);
			return o;
		}
 
		float4 frag(vertexOutput i) : COLOR
		{
			i.normal = normalize(i.normal);
			//视角法线
			float3 viewdir = normalize(i.worldvertpos.xyz - _WorldSpaceCameraPos.xyz);
			float4 color = _AtmoColor;
			//视角法线与模型法线点积形成中间为1向四周逐渐衰减为0的点积值，赋值透明通道，形成光晕效果
			color.a = pow(saturate(dot(viewdir, i.normal)),_OutLightPow);
			color.a *= _OutLightStrength * dot(viewdir, i.normal);
			return color;
		}
		ENDCG
	}
 
		}
			FallBack "Diffuse"

}
