// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Benttoenail/CustomShader/Nonsense"{
	Properties{
		_Color("Color", Color) = (1.0, 1.0, 1.0, 1.0)
	}
	SubShader{

		Pass{
		CGPROGRAM

		//pragmas
		#pragma vertex vert
		#pragma fragment frag

		//user defined variables
		uniform float4 _Color;

		//base input structs
		struct vertexInput{
			float4 vertex : POSITION;
		};

		struct vertexOutput{
			float4 pos : SV_POSITION;
		};

		//vertex function
		//Processing everything within the verticies
		vertexOutput vert(vertexInput v) {
			vertexOutput o;
			o.pos = UnityObjectToClipPos(v.vertex); //Convert Vertext space to Unity space

			return o;
		}

		//fragment function
		//Outputs actual pixel data
		float4 frag(vertexOutput i) : COLOR
		{
			return _Color;
		}

		ENDCG
		}
	}
		//Fallback 
	//Fallback "Diffuse";

}
