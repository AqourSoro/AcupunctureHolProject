// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:33209,y:32712,varname:node_9361,prsc:2|custl-2762-OUT;n:type:ShaderForge.SFN_Tex2d,id:6708,x:32423,y:32742,ptovrint:False,ptlb:texture,ptin:_texture,varname:node_6708,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:b66bceaf0cc0ace4e9bdc92f14bba709,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Fresnel,id:7263,x:32169,y:32938,varname:node_7263,prsc:2;n:type:ShaderForge.SFN_Power,id:1632,x:32577,y:33177,varname:node_1632,prsc:2|VAL-7263-OUT,EXP-4817-OUT;n:type:ShaderForge.SFN_Exp,id:4817,x:32332,y:33167,varname:node_4817,prsc:2,et:0|IN-824-OUT;n:type:ShaderForge.SFN_Slider,id:824,x:32012,y:33106,ptovrint:False,ptlb:width,ptin:_width,varname:node_824,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:3;n:type:ShaderForge.SFN_Multiply,id:8091,x:32802,y:33087,varname:node_8091,prsc:2|A-1716-RGB,B-1632-OUT;n:type:ShaderForge.SFN_Color,id:1716,x:32533,y:32995,ptovrint:False,ptlb:color,ptin:_color,varname:node_1716,prsc:2,glob:False,taghide:False,taghdr:True,tagprd:False,tagnsco:False,tagnrm:False,c1:0.6029412,c2:0.6029412,c3:0.6029412,c4:1;n:type:ShaderForge.SFN_Add,id:2762,x:32921,y:32820,varname:node_2762,prsc:2|A-6708-RGB,B-8091-OUT;proporder:6708-824-1716;pass:END;sub:END;*/

Shader "xiaoyisi/highlightOT" {
    Properties {
        _texture ("texture", 2D) = "white" {}
        _width ("width", Range(0, 3)) = 0
        [HDR]_color ("color", Color) = (0.6029412,0.6029412,0.6029412,1)
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 
            #pragma target 3.0
            uniform sampler2D _texture; uniform float4 _texture_ST;
            uniform float _width;
            uniform float4 _color;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
////// Lighting:
                float4 _texture_var = tex2D(_texture,TRANSFORM_TEX(i.uv0, _texture));
                float3 finalColor = (_texture_var.rgb+(_color.rgb*pow((1.0-max(0,dot(normalDirection, viewDirection))),exp(_width))));
                fixed4 finalRGBA = fixed4(finalColor,1);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
