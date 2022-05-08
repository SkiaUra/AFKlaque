// Amplify Shader Editor - Visual Shader Editing Tool
// Copyright (c) Amplify Creations, Lda <info@amplify.pt>
#if UNITY_POST_PROCESSING_STACK_V2
using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess( typeof( PixelisationPPSRenderer ), PostProcessEvent.AfterStack, "Pixelisation", true )]
public sealed class PixelisationPPSSettings : PostProcessEffectSettings
{
	[Tooltip( "Resolution" )]
	public FloatParameter _Resolution = new FloatParameter { value = 13.15f };
}

public sealed class PixelisationPPSRenderer : PostProcessEffectRenderer<PixelisationPPSSettings>
{
	public override void Render( PostProcessRenderContext context )
	{
		var sheet = context.propertySheets.Get( Shader.Find( "Pixelisation" ) );
		sheet.properties.SetFloat( "_Resolution", settings._Resolution );
		context.command.BlitFullscreenTriangle( context.source, context.destination, sheet, 0 );
	}
}
#endif
