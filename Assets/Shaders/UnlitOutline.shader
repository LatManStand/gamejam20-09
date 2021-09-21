Shader "Unlit/Outline"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Position("Posicion", Vector) = (0,0,0,0)
        _Speed("Velocidad", float) = 0
        _Outline("Outline", range(0,5)) = 0.1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        //LOD 100

        Pass{
            Blend One Zero
            Zwrite Off // Por defecto On
            ZTest Less
            Cull Front // Por defecto Back

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            //#pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertexPos : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f // Vertex to fragment; interpolador
            {
                float4 vertex : SV_POSITION;
            };

            float _Outline;

            v2f vert (appdata v)
            {
                v2f o;
                v.vertexPos.xyz += v.normal * _Outline;
                //v.vertexPos.xyz *= 1 + _Outline;
                o.vertex = UnityObjectToClipPos(v.vertexPos);
                return o;
            }
            
            //float4 _Tint;

            fixed4 frag (v2f i) : SV_Target
            {
                //return _Tint;
                return 0;
            }
            ENDCG
		}

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            //#pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertexPos : POSITION;
                float2 uv : TEXCOORD0;
                float2 uvLightMap : TEXCOORD1;
                fixed4 color : COLOR;
            };

            struct v2f // Vertex to fragment; interpolador
            {
                float2 uv : TEXCOORD0;
                float2 uvLM : TEXCOORD1;
                //UNITY_FOG_COORDS(1) // el  asigna una TEXCOORD1
                float4 vertex : SV_POSITION;
                fixed color : COLOR;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            uniform float4 _Tint;
            float _Speed;

            v2f vert (appdata v)
            {
                v2f o;
                //v.vertexPos.x += _SinTime.w;
                o.vertex = UnityObjectToClipPos(v.vertexPos);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                //o.uv.x += _Time.y * _Speed;
                o.uvLM =  v.uvLightMap;
                //UNITY_TRANSFER_FOG(o,o.vertex);
                o.color = v.color;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                //fixed4 col = tex2D(_MainTex, i.uv);
                //i.uv.y += sin(_Time.x * 0.1 + i.uv.x * 10) * 0.1;
                fixed4 col = tex2D(_MainTex, i.uv) * _Tint;
                // apply fog
                //UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
