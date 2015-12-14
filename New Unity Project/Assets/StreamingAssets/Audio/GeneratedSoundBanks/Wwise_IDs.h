/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID BAGJOSTLE = 2229533828U;
        static const AkUniqueID BUFFKICKERATTACK = 614269825U;
        static const AkUniqueID COLLISIONBARBEDWIRE = 2037222792U;
        static const AkUniqueID COLLISIONLANDMINE = 3926176201U;
        static const AkUniqueID COLLISIONTANKTRAP = 68125478U;
        static const AkUniqueID DESTROYDRONE_EXPLODE = 823393987U;
        static const AkUniqueID DESTROYDRONE_SPINOUT = 1088977592U;
        static const AkUniqueID DRONEATTACK = 2687191769U;
        static const AkUniqueID DRONESPAWN = 690362850U;
        static const AkUniqueID EXPLOSION = 13776098U;
        static const AkUniqueID PLAYDESERTAMB = 3938763508U;
        static const AkUniqueID PLAYGAMEOVERSTINGER = 698348403U;
        static const AkUniqueID PLAYTILTALERT = 2273201524U;
        static const AkUniqueID PLAYTITLEMUSIC = 718394488U;
        static const AkUniqueID STARTBIGDOG = 3499504239U;
        static const AkUniqueID STOPBIGDOG = 2195046349U;
        static const AkUniqueID STOPBIGDOG_NODELAY = 55290242U;
        static const AkUniqueID UI_CONFIRMMENU = 555737691U;
        static const AkUniqueID UI_OBSTACLEALERT = 1639539297U;
        static const AkUniqueID UI_SELECTMENU = 3497004131U;
        static const AkUniqueID UI_TILTALERTLEFT = 1637104820U;
        static const AkUniqueID UI_TILTALERTRIGHT = 3529644627U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace ENGINE
        {
            static const AkUniqueID GROUP = 268529915U;

            namespace STATE
            {
                static const AkUniqueID RUNNING = 3863236874U;
                static const AkUniqueID STOPPED = 2904797076U;
            } // namespace STATE
        } // namespace ENGINE

        namespace MUSIC
        {
            static const AkUniqueID GROUP = 3991942870U;

            namespace STATE
            {
                static const AkUniqueID BUILD = 3284755031U;
                static const AkUniqueID CUTSCENE_MAJOR = 615630075U;
                static const AkUniqueID CUTSCENE_MINOR = 3180957319U;
                static const AkUniqueID ENDING_SAD = 2635390553U;
                static const AkUniqueID GAMEPLAY = 89505537U;
                static const AkUniqueID INTRO = 1125500713U;
            } // namespace STATE
        } // namespace MUSIC

        namespace TILT_DIRECTION
        {
            static const AkUniqueID GROUP = 3629189662U;

            namespace STATE
            {
                static const AkUniqueID LEFT = 4109362U;
                static const AkUniqueID RIGHT = 3893817417U;
            } // namespace STATE
        } // namespace TILT_DIRECTION

    } // namespace STATES

    namespace SWITCHES
    {
        namespace DRONESTATE
        {
            static const AkUniqueID GROUP = 3733145084U;

            namespace SWITCH
            {
                static const AkUniqueID ALIVE = 655265632U;
                static const AkUniqueID DEAD = 2044049779U;
            } // namespace SWITCH
        } // namespace DRONESTATE

    } // namespace SWITCHES

    namespace GAME_PARAMETERS
    {
        static const AkUniqueID BIGDOG_SPEED = 3395678809U;
        static const AkUniqueID DISTANCE = 1240670792U;
        static const AkUniqueID TILT_AMOUNT = 2127427523U;
    } // namespace GAME_PARAMETERS

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID MAIN = 3161908922U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID ENEMIES = 2242381963U;
        static const AkUniqueID ENVIRONMENT = 1229948536U;
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
        static const AkUniqueID MASTER_SECONDARY_BUS = 805203703U;
        static const AkUniqueID MUSIC = 3991942870U;
        static const AkUniqueID OBSTACLES = 2977111165U;
        static const AkUniqueID PLAYER = 1069431850U;
        static const AkUniqueID SFX = 393239870U;
        static const AkUniqueID UI = 1551306167U;
    } // namespace BUSSES

}// namespace AK

#endif // __WWISE_IDS_H__
