def new_deck():
    """
    This function will create a deck of cards
    """
    deck = []
    for suit in ['Spades', 'Hearts', 'Diamonds', 'Clubs']:
        for rank in range(2, 15):
            deck.append((suit, rank))
    return deck

def shuffle_deck(deck):
    """
    This function will shuffle the deck of cards
    """
    import random
    random.shuffle(deck)
    return deck

def print_hand(hand):
    arr = []
    for i in range(len(hand)):
        suit = hand[i][0]
        rank = ''
        if hand[i][1] == 10: rank = 'Ten'
        elif hand[i][1] == 11: rank = 'Jack'
        elif hand[i][1] == 12: rank = 'Queen'
        elif hand[i][1] == 13: rank = 'King'
        elif hand[i][1] == 14: rank = 'Ace'
        else: rank = str(hand[i][1])
        arr.append(f"{rank} of {suit}")
    return arr

def hand_of_same_suit(hand):
    """
    This function will check if the hand has cards of the same suit
    """
    for i in range(len(hand)-1):
        if hand[i][0] != hand[i+1][0]:
            return False
    return True

def hand_of_consecutive_ranks(hand):
    """
    This function will check if the hand has cards of consecutive ranks
    """
    for i in range(len(hand)-1):
        if hand[i][1] != hand[i+1][1]-1:
            return False
    return True

def four_of_a_kind(hand):
    """
    This function will check if the hand has four cards of the same rank
    """
    assert len(hand) > 3
    for i in range(len(hand)-3):
        if hand[i][1] == hand[i+1][1] == hand[i+2][1] == hand[i+3][1]:
            return True
    return False

def full_house(hand):
    """
    This function will check if the hand is a full house
    """
    assert len(hand) == 5
    if hand[0][1] == hand[1][1] == hand[2][1] and hand [3][1] == hand[4][1]:
        return True
    
    if hand[0][1] == hand[1][1] and hand[2][1] == hand[3][1] == hand[4][1]:
        return True

    return False

def three_of_a_kind(hand):
    """
    This function will check if the hand has three cards of the same rank
    """
    assert len(hand) > 2
    for i in range(len(hand)-2):
        if hand[i][1] == hand[i+1][1] == hand[i+2][1]:
            return True
    return False

def two_pair(hand):
    """
    This function will check if the hand has two pairs
    """
    assert len(hand) == 5
    for i in range(len(hand)-3):
        if hand[i][1] == hand[i+1][1]:
            for j in range(i+1, len(hand)-1):
                if hand[j][1] == hand[j+1][1]:
                    return True
    return False

def pair(hand):
    """
    This function will check if the hand has a pair
    """
    assert len(hand) == 5
    for i in range(len(hand)-1):
        if hand[i][1] == hand[i+1][1]:
            return True
    return False

def score(R):
    R.sort(key=lambda x:x[1])
    if hand_of_same_suit(R):
        if(hand_of_consecutive_ranks(R)):
            if R[0][1] == 10: return (10, "Royal Flush")
            else: return (9, "Straight Flush")
        else:
            return (6, "Flush")
    elif four_of_a_kind(R): return (8, "Four of a Kind")
    elif full_house(R): return (7, "Full House")
    elif hand_of_consecutive_ranks(R): return (5, "Straight")
    elif three_of_a_kind(R): return (4, "Three of a Kind")
    elif two_pair(R): return (3, "Two Pair")
    elif pair(R): return (2, "Pair")
    else: return (1, f"High Card {R[-1][1]}")

round = 0  

while True:
    round += 1
    D = shuffle_deck(new_deck())
    R = []

    for card in range(5):
        R.append(D.pop())

    S = score(R) 

    if S[0] > 9:
        print(f'round: {round}, score: {S[0]} "{S[1]}", hand: {print_hand(R)}')
        break 

    
