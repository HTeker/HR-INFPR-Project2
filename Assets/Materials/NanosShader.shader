#warning Upgrade NOTE: unity_Scale shader variable was removed; replaced 'unity_Scale.w' with '1.0'
// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.04 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.04;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,limd:1,uamb:True,mssp:True,lmpd:False,lprd:True,rprd:False,enco:False,frtr:True,vitr:True,dbil:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,tesm:0,blpr:0,bsrc:0,bdst:0,culm:0,dpts:2,wrdp:True,dith:2,ufog:True,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:1,x:33430,y:32397,cmnt:SUPER SHADER,varname:node_1,prsc:2|diff-149-OUT,spec-4921-OUT,normal-4935-OUT,emission-166-OUT,difocc-6909-OUT,voffset-140-OUT;n:type:ShaderForge.SFN_Subtract,id:18,x:30205,y:30625,varname:node_18,prsc:2|A-22-OUT,B-19-OUT;n:type:ShaderForge.SFN_Vector1,id:19,x:29978,y:30652,varname:node_19,prsc:2,v1:0.5;n:type:ShaderForge.SFN_Abs,id:21,x:30432,y:30689,varname:node_21,prsc:2|IN-18-OUT;n:type:ShaderForge.SFN_Frac,id:22,x:29978,y:30484,varname:node_22,prsc:2|IN-24-OUT;n:type:ShaderForge.SFN_Panner,id:23,x:29481,y:30349,varname:node_23,prsc:2,spu:1,spv:1;n:type:ShaderForge.SFN_ComponentMask,id:24,x:29751,y:30415,varname:node_24,prsc:2,cc1:1,cc2:-1,cc3:-1,cc4:-1|IN-23-UVOUT;n:type:ShaderForge.SFN_Multiply,id:25,x:30659,y:30825,cmnt:Triangle Wave,varname:node_25,prsc:2|A-21-OUT,B-26-OUT;n:type:ShaderForge.SFN_Vector1,id:26,x:30432,y:30857,varname:node_26,prsc:2,v1:2;n:type:ShaderForge.SFN_Power,id:133,x:30867,y:30978,cmnt:Panning gradient,varname:node_133,prsc:2|VAL-25-OUT,EXP-8547-OUT;n:type:ShaderForge.SFN_NormalVector,id:139,x:31113,y:31449,prsc:2,pt:True;n:type:ShaderForge.SFN_Multiply,id:140,x:31340,y:31279,varname:node_140,prsc:2|A-133-OUT,B-142-OUT,C-139-OUT;n:type:ShaderForge.SFN_ValueProperty,id:142,x:31113,y:31281,ptovrint:False,ptlb:Bulge Scale,ptin:_BulgeScale,varname:_BulgeScale,prsc:2,glob:False,v1:0;n:type:ShaderForge.SFN_Lerp,id:149,x:31340,y:30607,varname:node_149,prsc:2|A-151-RGB,B-8608-OUT,T-133-OUT;n:type:ShaderForge.SFN_Lerp,id:150,x:31113,y:30777,varname:node_150,prsc:2|A-267-RGB,B-265-OUT,T-133-OUT;n:type:ShaderForge.SFN_Tex2d,id:151,x:31113,y:30441,ptovrint:False,ptlb:Diffuse,ptin:_Diffuse,varname:_Diffuse,prsc:2,tex:b66bceaf0cc0ace4e9bdc92f14bba709,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:166,x:31340,y:31111,cmnt:Glow,varname:node_166,prsc:2|A-168-RGB,B-8677-OUT,C-133-OUT;n:type:ShaderForge.SFN_Color,id:168,x:31113,y:30945,ptovrint:False,ptlb:Glow Color,ptin:_GlowColor,varname:_GlowColor,prsc:2,glob:False,c1:0.1102941,c2:0.4845841,c3:1,c4:1;n:type:ShaderForge.SFN_Vector3,id:265,x:30867,y:30795,varname:node_265,prsc:2,v1:0,v2:0,v3:1;n:type:ShaderForge.SFN_Tex2d,id:267,x:30886,y:30625,ptovrint:False,ptlb:Normals,ptin:_Normals,varname:_Normals,prsc:2,tex:bbab0a6f7bae9cf42bf057d8ee2755f6,ntxv:3,isnm:True;n:type:ShaderForge.SFN_Vector1,id:4921,x:31340,y:30775,varname:node_4921,prsc:2,v1:1;n:type:ShaderForge.SFN_Normalize,id:4935,x:31340,y:30943,varname:node_4935,prsc:2|IN-150-OUT;n:type:ShaderForge.SFN_ValueProperty,id:8547,x:30659,y:30993,ptovrint:False,ptlb:Bulge Shape,ptin:_BulgeShape,varname:_BulgeShape,prsc:2,glob:False,v1:15;n:type:ShaderForge.SFN_Vector1,id:8608,x:31113,y:30609,varname:node_8608,prsc:2,v1:0.1;n:type:ShaderForge.SFN_ValueProperty,id:8677,x:31113,y:31113,ptovrint:False,ptlb:Glow Intensity,ptin:_GlowIntensity,varname:_GlowIntensity,prsc:2,glob:False,v1:1;n:type:ShaderForge.SFN_TexCoord,id:9931,x:30527,y:30373,varname:node_9931,prsc:2,uv:0;n:type:ShaderForge.SFN_Fresnel,id:8271,x:32621,y:32654,varname:node_8271,prsc:2|EXP-567-OUT;n:type:ShaderForge.SFN_Slider,id:567,x:32515,y:32846,ptovrint:False,ptlb:node_567,ptin:_node_567,varname:node_567,prsc:2,min:-10,cur:1,max:3;n:type:ShaderForge.SFN_ValueProperty,id:7238,x:32260,y:32780,ptovrint:False,ptlb:node_7238,ptin:_node_7238,varname:node_7238,prsc:2,glob:False,v1:5;n:type:ShaderForge.SFN_Multiply,id:1658,x:32477,y:32509,varname:node_1658,prsc:2|A-8271-OUT,B-7238-OUT,C-1232-RGB;n:type:ShaderForge.SFN_Color,id:1232,x:31986,y:32634,ptovrint:False,ptlb:node_1232,ptin:_node_1232,varname:node_1232,prsc:2,glob:False,c1:0,c2:0.827451,c3:0.7607843,c4:1;n:type:ShaderForge.SFN_ChannelBlend,id:4549,x:32220,y:32344,varname:node_4549,prsc:2,chbt:0|M-4592-OUT,R-1658-OUT;n:type:ShaderForge.SFN_OneMinus,id:4592,x:31649,y:32130,varname:node_4592,prsc:2|IN-5790-OUT;n:type:ShaderForge.SFN_Dot,id:5790,x:32220,y:31970,varname:node_5790,prsc:2,dt:0|A-1025-RGB,B-1537-OUT;n:type:ShaderForge.SFN_LightVector,id:1537,x:31924,y:31953,varname:node_1537,prsc:2;n:type:ShaderForge.SFN_ChannelBlend,id:9504,x:32220,y:32143,varname:node_9504,prsc:2,chbt:0|M-4592-OUT,R-7005-RGB;n:type:ShaderForge.SFN_Color,id:7005,x:31877,y:32329,ptovrint:False,ptlb:node_7005,ptin:_node_7005,varname:node_7005,prsc:2,glob:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Add,id:6909,x:32632,y:32269,varname:node_6909,prsc:2|A-9504-OUT,B-4549-OUT;n:type:ShaderForge.SFN_AmbientLight,id:1025,x:32170,y:31737,varname:node_1025,prsc:2;proporder:151-267-168-142-8547-8677-567-7238-1232-7005;pass:END;sub:END;*/

Shader "Shader Forge/Examples/Vertex Animation" {
    Properties {
        _Diffuse ("Diffuse", 2D) = "white" {}
        _Normals ("Normals", 2D) = "bump" {}
        _GlowColor ("Glow Color", Color) = (0.1102941,0.4845841,1,1)
        _BulgeScale ("Bulge Scale", Float ) = 0
        _BulgeShape ("Bulge Shape", Float ) = 15
        _GlowIntensity ("Glow Intensity", Float ) = 1
        _node_567 ("node_567", Range(-10, 3)) = 1
        _node_7238 ("node_7238", Float ) = 5
        _node_1232 ("node_1232", Color) = (0,0.827451,0.7607843,1)
        _node_7005 ("node_7005", Color) = (0.5,0.5,0.5,1)
    }
    SubShader {
        Tags {
            "RenderType"="Opaque"
        }
        Pass {
            Name "ForwardBase"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #define SHOULD_SAMPLE_SH_PROBE ( defined (LIGHTMAP_OFF) )
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma exclude_renderers xbox360 ps3 flash 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform float _BulgeScale;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float4 _GlowColor;
            uniform sampler2D _Normals; uniform float4 _Normals_ST;
            uniform float _BulgeShape;
            uniform float _GlowIntensity;
            uniform float _node_567;
            uniform float _node_7238;
            uniform float4 _node_1232;
            uniform float4 _node_7005;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 binormalDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
                float3 shLight : TEXCOORD7;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                #if SHOULD_SAMPLE_SH_PROBE
                    o.shLight = ShadeSH9(float4(mul(unity_ObjectToWorld, float4(v.normal,0)).xyz * 1.0,1)) * 0.5;
                #endif
                o.normalDir = mul(unity_ObjectToWorld, float4(v.normal,0)).xyz;
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.binormalDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float4 node_4106 = _Time + _TimeEditor;
                float node_133 = pow((abs((frac((o.uv0+node_4106.g*float2(1,1)).g)-0.5))*2.0),_BulgeShape); // Panning gradient
                v.vertex.xyz += (node_133*_BulgeScale*v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.binormalDir, i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normals_var = UnpackNormal(tex2D(_Normals,TRANSFORM_TEX(i.uv0, _Normals)));
                float4 node_4106 = _Time + _TimeEditor;
                float node_133 = pow((abs((frac((i.uv0+node_4106.g*float2(1,1)).g)-0.5))*2.0),_BulgeShape); // Panning gradient
                float3 normalLocal = normalize(lerp(_Normals_var.rgb,float3(0,0,1),node_133));
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float node_4921 = 1.0;
                float3 specularColor = float3(node_4921,node_4921,node_4921);
                float3 directSpecular = (floor(attenuation) * _LightColor0.xyz) * pow(max(0,dot(halfDirection,normalDirection)),specPow);
                float3 specular = directSpecular * specularColor;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 indirectDiffuse = float3(0,0,0);
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                #if SHOULD_SAMPLE_SH_PROBE
                    indirectDiffuse += i.shLight; // Per-Vertex Light Probes / Spherical harmonics
                #endif
                float node_4592 = (1.0 - dot(UNITY_LIGHTMODEL_AMBIENT.rgb,lightDirection));
                indirectDiffuse *= ((node_4592.r*_node_7005.rgb)+(node_4592.r*(pow(1.0-max(0,dot(normalDirection, viewDirection)),_node_567)*_node_7238*_node_1232.rgb))); // Diffuse AO
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float node_8608 = 0.1;
                float3 diffuse = (directDiffuse + indirectDiffuse) * lerp(_Diffuse_var.rgb,float3(node_8608,node_8608,node_8608),node_133);
////// Emissive:
                float3 emissive = (_GlowColor.rgb*_GlowIntensity*node_133);
/// Final Color:
                float3 finalColor = diffuse + specular + emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ForwardAdd"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            
            
            Fog { Color (0,0,0,0) }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #define SHOULD_SAMPLE_SH_PROBE ( defined (LIGHTMAP_OFF) )
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd_fullshadows
            #pragma exclude_renderers xbox360 ps3 flash 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float4 _TimeEditor;
            uniform float _BulgeScale;
            uniform sampler2D _Diffuse; uniform float4 _Diffuse_ST;
            uniform float4 _GlowColor;
            uniform sampler2D _Normals; uniform float4 _Normals_ST;
            uniform float _BulgeShape;
            uniform float _GlowIntensity;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float3 tangentDir : TEXCOORD3;
                float3 binormalDir : TEXCOORD4;
                LIGHTING_COORDS(5,6)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(unity_ObjectToWorld, float4(v.normal,0)).xyz;
                o.tangentDir = normalize( mul( unity_ObjectToWorld, float4( v.tangent.xyz, 0.0 ) ).xyz );
                o.binormalDir = normalize(cross(o.normalDir, o.tangentDir) * v.tangent.w);
                float4 node_8362 = _Time + _TimeEditor;
                float node_133 = pow((abs((frac((o.uv0+node_8362.g*float2(1,1)).g)-0.5))*2.0),_BulgeShape); // Panning gradient
                v.vertex.xyz += (node_133*_BulgeScale*v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3x3 tangentTransform = float3x3( i.tangentDir, i.binormalDir, i.normalDir);
/////// Vectors:
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 _Normals_var = UnpackNormal(tex2D(_Normals,TRANSFORM_TEX(i.uv0, _Normals)));
                float4 node_8362 = _Time + _TimeEditor;
                float node_133 = pow((abs((frac((i.uv0+node_8362.g*float2(1,1)).g)-0.5))*2.0),_BulgeShape); // Panning gradient
                float3 normalLocal = normalize(lerp(_Normals_var.rgb,float3(0,0,1),node_133));
                float3 normalDirection = normalize(mul( normalLocal, tangentTransform )); // Perturbed normals
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
///////// Gloss:
                float gloss = 0.5;
                float specPow = exp2( gloss * 10.0+1.0);
////// Specular:
                float NdotL = max(0, dot( normalDirection, lightDirection ));
                float node_4921 = 1.0;
                float3 specularColor = float3(node_4921,node_4921,node_4921);
                float3 directSpecular = attenColor * pow(max(0,dot(halfDirection,normalDirection)),specPow);
                float3 specular = directSpecular * specularColor;
/////// Diffuse:
                NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 _Diffuse_var = tex2D(_Diffuse,TRANSFORM_TEX(i.uv0, _Diffuse));
                float node_8608 = 0.1;
                float3 diffuse = directDiffuse * lerp(_Diffuse_var.rgb,float3(node_8608,node_8608,node_8608),node_133);
/// Final Color:
                float3 finalColor = diffuse + specular;
                return fixed4(finalColor * 1,0);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCollector"
            Tags {
                "LightMode"="ShadowCollector"
            }
            
            Fog {Mode Off}
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCOLLECTOR
            #define SHADOW_COLLECTOR_PASS
            #define SHOULD_SAMPLE_SH_PROBE ( defined (LIGHTMAP_OFF) )
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcollector
            #pragma exclude_renderers xbox360 ps3 flash 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float _BulgeScale;
            uniform float _BulgeShape;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_COLLECTOR;
                float2 uv0 : TEXCOORD5;
                float3 normalDir : TEXCOORD6;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(unity_ObjectToWorld, float4(v.normal,0)).xyz;
                float4 node_4829 = _Time + _TimeEditor;
                float node_133 = pow((abs((frac((o.uv0+node_4829.g*float2(1,1)).g)-0.5))*2.0),_BulgeShape); // Panning gradient
                v.vertex.xyz += (node_133*_BulgeScale*v.normal);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_SHADOW_COLLECTOR(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
/////// Vectors:
                SHADOW_COLLECTOR_FRAGMENT(i)
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Cull Off
            Offset 1, 1
            
            Fog {Mode Off}
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #define SHOULD_SAMPLE_SH_PROBE ( defined (LIGHTMAP_OFF) )
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma exclude_renderers xbox360 ps3 flash 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float _BulgeScale;
            uniform float _BulgeShape;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(unity_ObjectToWorld, float4(v.normal,0)).xyz;
                float4 node_287 = _Time + _TimeEditor;
                float node_133 = pow((abs((frac((o.uv0+node_287.g*float2(1,1)).g)-0.5))*2.0),_BulgeShape); // Panning gradient
                v.vertex.xyz += (node_133*_BulgeScale*v.normal);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
/////// Vectors:
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
