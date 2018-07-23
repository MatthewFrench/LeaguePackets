using System;
using System.Numerics;

namespace LeaguePackets.Common
{
    public struct WaypointSpeedParams
    {
        public float PathSpeedOverride { get; set; }
        public float ParabolicGravity { get; set; }
        public Vector2 ParabolicStartPoint { get; set; }
        public bool Facing { get; set; }
        public NetID FollowNetID { get; set; }
        public float FollowDistance { get; set; }
        public float FollowBackDistance { get; set; }
        public float FollowTravelTime { get; set; }
    }
}
