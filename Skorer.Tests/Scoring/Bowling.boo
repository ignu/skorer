
if matchEvent.Quantity == 0:
	return
		
bowler = matchEvent.Player
frame = PlayerRound(bowler)

# if we're editing a previous event, we don't want to end up 
# adding duplicate of these events, so lets just be safe and 
# delete them
frame.DeletePlayerEventsByEventName(bowler, "StrikeBonus") 
frame.DeletePlayerEventsByEventName(bowler, "SpareBonus")

# Doesn't work
# TODO: figure out how to inject this method, as it would make our main algorithm much more readable
#def GotStrike(Player bowler, Round round) as bool:
#	return round.GetEventsFor(bowler).Count == 1 && round.GetScoreFor(bowler) == 10
#end	

matchEvent.Score = matchEvent.Quantity * matchEvent.GameEvent.Points
	
if frame.GetScoreFor(bowler) == 10:
	if frame.GetEventsFor(bowler).Count == 1: 		
		AddEvent("StrikeBonus", bowler, 0)		 		
	elif frame.GetEventsFor(bowler).Count == 2:		
		AddEvent("SpareBonus", bowler, 0) 
		
if frame.Previous != null and frame.Previous.GetScoreFor(bowler) == 10:
	if frame.Previous.FindPlayerEventsByEventName(bowler, "StrikeBonus") != null and frame.Previous.FindPlayerEventsByEventName(bowler, "StrikeBonus").Count > 0:		
		frame.Previous.FindPlayerEventsByEventName(bowler, "StrikeBonus")[0].Score = matchEvent.Quantity
		if frame.Previous.Previous != null and frame.Previous.Previous.GetScoreFor(bowler) == 10 and frame.Previous.Previous.GetEventsFor(bowler).Count == 1:
			frame.Previous.Previous.FindPlayerEventsByEventName(bowler, "StrikeBonus")[0].Score = matchEvent.Quantity
	else:
		frame.Previous.FindPlayerEventsByEventName(bowler, "SpareBonus")[0].Score = matchEvent.Quantity
	
if frame.GetEventsFor(bowler).Count >= 2:
	NewRound(bowler)


