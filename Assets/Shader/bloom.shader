Shader "Custom/bloom"
{
    // ---------------------------�����ԡ�---------------------------
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
    }
        // ---------------------------������ɫ����---------------------------
        SubShader
    {
        //����Ч��һ�㶼���⼸��״̬  
        ZTest Always
        Cull Off
        ZWrite Off
        Fog{ Mode Off }

        CGINCLUDE
        #include "UnityCG.cginc"

        sampler2D _MainTex;
        half4 _MainTex_TexelSize;
        sampler2D _BlurTex;
        float4 _offsets;
        float _LuminanceThreshold;
        fixed4 _BloomColor;
        float _BloomFactor;

        // ---------------------------��������ȡ - start��---------------------------
        struct v2fExtBright {
            float4 pos : SV_POSITION;
            half2 uv : TEXCOORD0;
        };
        // ������ɫ��
        v2fExtBright vertExtractBright(appdata_img v) {
            v2fExtBright o;

            o.pos = UnityObjectToClipPos(v.vertex);
            o.uv = v.texcoord;

            return o;
        }
        // ������ȡ
        fixed luminance(fixed4 color) {
            return  0.2125 * color.r + 0.7154 * color.g + 0.0721 * color.b;
        }
        // ƬԪ��ɫ��
        fixed4 fragExtractBright(v2fExtBright i) : SV_Target {
            fixed4 color = tex2D(_MainTex, i.uv);
        // clamp Լ���� 0 - 1 ����
        fixed val = clamp(luminance(color) - _LuminanceThreshold, 0.0, 1.0);

        return color * val;
    }
            // ---------------------------��������ȡ - end��---------------------------



            // ---------------------------����˹ģ�� - start��---------------------------
            struct v2fBlur
            {
                float4 pos : SV_POSITION;   //����λ��  
                float2 uv  : TEXCOORD0;     //��������  
                float4 uv01 : TEXCOORD1;    //һ��vector4�洢������������  
                float4 uv23 : TEXCOORD2;    //һ��vector4�洢������������  
            };

    //��˹ģ��������ɫ��
    v2fBlur vertBlur(appdata_img v)
    {
        v2fBlur o;
        o.pos = UnityObjectToClipPos(v.vertex);
        //uv����  
        o.uv = v.texcoord.xy;

        //����һ��ƫ��ֵ��offset�����ǣ�1��0��0��0��Ҳ�����ǣ�0��1��0��0�������ͱ�ʾ�˺����������ȡ������Χ�ĵ�  
        _offsets *= _MainTex_TexelSize.xyxy;

        //����uv���Դ洢4��ֵ������һ��uv��������vector���꣬_offsets.xyxy * float4(1,1,-1,-1)���ܱ�ʾ(0,1,0-1)����ʾ������������  
        //���꣬Ҳ������(1,0,-1,0)����ʾ���������������ص�����꣬����*2.0��*3.0ͬ��  
        o.uv01 = v.texcoord.xyxy + _offsets.xyxy * float4(1, 1, -1, -1);
        o.uv23 = v.texcoord.xyxy + _offsets.xyxy * float4(1, 1, -1, -1) * 2.0;
        return o;
    }

    //��˹ģ��Ƭ����ɫ��
    fixed4 fragBlur(v2fBlur i) : SV_Target
    {
        fixed4 color = fixed4(0,0,0,0);
        color += 0.4026 * tex2D(_MainTex, i.uv);
        color += 0.2442 * tex2D(_MainTex, i.uv01.xy);
        color += 0.2442 * tex2D(_MainTex, i.uv01.zw);
        color += 0.0545 * tex2D(_MainTex, i.uv23.xy);
        color += 0.0545 * tex2D(_MainTex, i.uv23.zw);
        return color;
    }
        // ---------------------------����˹ģ�� - end��---------------------------

        // ---------------------------��Bloom(��˹ģ����ԭͼ����) - start��---------------------------
        struct v2fBloom {
            float4 pos : SV_POSITION;
            half2 uv : TEXCOORD0;
        };
    // ������ɫ��
    v2fBloom vertBloom(appdata_img v) {
        v2fBloom o;

        o.pos = UnityObjectToClipPos(v.vertex);
        o.uv = v.texcoord;
        return o;
    }

    // ƬԪ��ɫ��
    fixed4 fragBloom(v2fBloom i) : SV_Target {
        //��ԭͼ����uv����
        fixed4 mainColor = tex2D(_MainTex, i.uv);
    //��ģ��������ͼ����uv����
    fixed4 blurColor = tex2D(_BlurTex, i.uv);
    //��� = ԭʼͼ�� + ģ��ͼ�� * bloom��ɫ * bloomȨֵ
    fixed4 resColor = mainColor + blurColor * _BloomColor * _BloomFactor;
    return resColor;
}
// ---------------------------��Bloom - end��---------------------------

ENDCG

// ������ȡ
Pass {
    CGPROGRAM
    #pragma vertex vertExtractBright  
    #pragma fragment fragExtractBright  
    ENDCG
}

//��˹ģ��
Pass {
    CGPROGRAM
    #pragma vertex vertBlur  
    #pragma fragment fragBlur
    ENDCG
}

// Bloom
Pass {
    CGPROGRAM
    #pragma vertex vertBloom  
    #pragma fragment fragBloom
    ENDCG
}

    }

}
