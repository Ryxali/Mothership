// Copyright 1998-2015 Epic Games, Inc. All Rights Reserved.

#include "Mothership.h"
#include "MothershipGameMode.h"
#include "MothershipPawn.h"

AMothershipGameMode::AMothershipGameMode()
{
	// set default pawn class to our character class
	DefaultPawnClass = AMothershipPawn::StaticClass();
}

