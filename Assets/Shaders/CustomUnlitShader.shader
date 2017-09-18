Shader "Benttoenail/CustomShader/Nonsense"{
	Properties{
		_Color("Color", Color) = (1, 1, 1, 1)
	}
	SubShader{

		Pass{
		CGPROGRAM

		//pragmas

		//user defined variables
		uniform float4 _Color;

		//base input structs
		struct vertexInput(){
			float4 vertex : POSITION;
		};

		struct vertexOutput(){

		};

		//vertex function

		//fragment function
		void Main(){

		}

		ENDCG
		}


	}

}
