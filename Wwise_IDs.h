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
        static const AkUniqueID PLAY_CREATE = 1298183142U;
        static const AkUniqueID PLAY_FOOTSTEPS = 3854155799U;
        static const AkUniqueID PLAY_MUS_GAMEPLAY = 2201569778U;
        static const AkUniqueID PLAY_UI_MENU_HOVER_OFF = 3364556447U;
        static const AkUniqueID PLAY_UI_MENU_HOVER_ON = 149435595U;
        static const AkUniqueID PLAY_UI_MENU_OVERVIEW = 171419728U;
        static const AkUniqueID PLAY_UI_MENU_OVERVIEW_BACK = 1828689550U;
        static const AkUniqueID PLAY_UI_MENU_TOGGLE_LEFT = 1448346335U;
        static const AkUniqueID PLAY_UI_MENU_TOGGLE_RIGHT = 1910474978U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace GAMEPLAY
        {
            static const AkUniqueID GROUP = 89505537U;

            namespace STATE
            {
                static const AkUniqueID MENU = 2607556080U;
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID OVERVIEW = 2617105480U;
            } // namespace STATE
        } // namespace GAMEPLAY

    } // namespace STATES

    namespace SWITCHES
    {
        namespace FOOSTEPS
        {
            static const AkUniqueID GROUP = 1012989952U;

            namespace SWITCH
            {
                static const AkUniqueID CARPET = 2412606308U;
                static const AkUniqueID HARDFLOOR = 3928445212U;
            } // namespace SWITCH
        } // namespace FOOSTEPS

    } // namespace SWITCHES

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID MAIN = 3161908922U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
    } // namespace BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
