// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/加油shader"
{
	Properties
	{
		// 泛光颜色
				_Color("Color",color) = (1,1,1,1)
				// 泛光效果强度
						_Scale("Scale",Range(1,8)) = 1
		// 泛光大小范围
				_Outer("Outer",range(0,20)) = 0.2
	}

		SubShader
	{
		// 通过标签对透明物体渲染进行排序
		tags{"queue" = "transparent"}

		// 该pass用于实现物体外部边缘的泛光的效果
	pass
		{
		// Alpha混合
		blend srcalpha oneminussrcalpha
			// 取消将深度写入深度缓存
			zwrite off
			CGPROGRAM
	#pragma vertex vert
	#pragma fragment frag
	#include "unitycg.cginc"

				float _Scale;
				float4 _Color;
				float _Outer;

			struct v2f
			{
				float4 pos: POSITION;
				float3 normal: TEXCOORD0;
				float4 vertex: TEXCOORD1;
			};

			// 顶点函数
			v2f vert(appdata_base v)
			{
				// 将顶点沿着法线方向扩展
				v.vertex.xyz += v.normal * _Outer;

				v2f o;
				// 将顶点转换到投影空间
				o.pos = UnityObjectToClipPos(v.vertex);

				// 将原始数据传递给结构体
				o.vertex = v.vertex;
				o.normal = v.normal;
				return o;
			}

			// 片段函数
			fixed4 frag(v2f IN) :COLOR
			{
				// 计算世界空间法线向量
				float3 N = normalize(mul(IN.normal,(float3x3)unity_WorldToObject));

				// 计算世界空间顶点位置
				float3 worldPos = mul(unity_ObjectToWorld,IN.vertex).xyz;

				// 计算从顶点指向摄像机的向量
				float3 V = normalize(_WorldSpaceCameraPos.xyz - worldPos);

				float bright = saturate(dot(N, V));
				bright = pow(bright,_Scale);
				_Color.a *= bright;
				return _Color;
			}
				ENDCG
		}

	// ===================================================
// 该pass用于防止物体中心颜色过于明亮
	pass
	{
			blendop revsub
				// Alpha混合
				blend dstalpha one
				// 取消深度的写入
				zwrite off
				CGPROGRAM
	#pragma vertex vert
	#pragma fragment frag
	#include "unitycg.cginc"

				float _Scale;

			struct v2f
			{
				float4 pos: POSITION;
			};

			// 顶点函数
			v2f vert(appdata_base v)
			{
				v2f o;
				// 将顶点转换到投影空间
				o.pos = UnityObjectToClipPos(v.vertex);
				return o;
			}

			// 片段函数
			fixed4 frag(v2f IN) :COLOR
			{
				return fixed4(1,1,1,1);
			}
				ENDCG
		}

	// ===================================================
//	该pass用于实现物体的半透明效果
	pass
	{
		/*blend zero one*/
		// Alpha混合
		blend srcalpha oneminussrcalpha
			// 取消深度的写入
			zwrite off
			CGPROGRAM
	#pragma vertex vert
	#pragma fragment frag
	#include "unitycg.cginc"

			float _Scale;

			struct v2f
			{
				float4 pos: POSITION;
				float3 normal: TEXCOORD0;
				float4 vertex: TEXCOORD1;
			};

			// 顶点函数
			v2f vert(appdata_base v)
			{
				v2f o;
				// 将顶点转换到投影空间
				o.pos = UnityObjectToClipPos(v.vertex);

				// 将原始数据传递给结构体
				o.vertex = v.vertex;
				o.normal = v.normal;
				return o;
			}

			// 片段函数
			fixed4 frag(v2f IN) :COLOR
			{
				// 计算世界空间法线向量
				float3 N = normalize(mul(IN.normal,(float3x3)unity_WorldToObject));

				// 计算世界空间顶点位置
				float3 worldPos = mul(unity_ObjectToWorld,IN.vertex).xyz;

				// 计算从顶点指向摄像机的向量
				float3 V = normalize(_WorldSpaceCameraPos.xyz - worldPos);

				float bright = 1 - saturate(dot(N, V));
				bright = pow(bright,_Scale);
				return fixed4(1,1,1,1) * bright;
			}
			ENDCG
		}
	}
	
}
