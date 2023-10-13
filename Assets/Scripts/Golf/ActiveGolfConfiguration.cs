﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
	[CreateAssetMenu(fileName = "Caddy", menuName = "Golf/Caddy", order = 0)]
	public class ActiveGolfConfiguration : ScriptableObject
	{
		public Action<Club> OnSelectedClubChanged;

		[SerializeField] private List<Club> clubs;
		private int selectedClubIndex = 0;
		public Club SelectedClub => clubs[selectedClubIndex];

		public void CycleClub(int delta = 1)
		{
			selectedClubIndex+=delta;
			if (selectedClubIndex >= clubs.Count)
			{
				selectedClubIndex = 0;
			}

			if (selectedClubIndex < 0)
			{
				selectedClubIndex = clubs.Count - 1;
			}
			
			//alert anyone who cares that the selected club has changed.
			OnSelectedClubChanged?.Invoke(SelectedClub);
		}
	}
}