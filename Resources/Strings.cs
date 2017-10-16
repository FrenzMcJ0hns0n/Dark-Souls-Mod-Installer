
namespace Resources {

    public class Strings {


        #region ConfigTool - GUI items

        public static string groupBox_resolutionOptions_headerLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Résolution";
                case "sp":
                    return "Resolución";
                default:
                    return "Resolution";
            }
        }

        public static string label_renderRes_contentLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Rendu";
                case "sp":
                    return "Principal";
                default:
                    return "Rendering";
            }
        }

        public static string label_renderRes_toolTipLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Résolution de rendu principal du jeu. Idéalement, choisissez la résolution native de votre écran.\n\n"
                         + "Des valeurs inférieures offrent de meilleures performances (mais dans ce cas voir réglage \"Interface\")"
                         ;
                case "sp":
                    return "La resolución principal del juego. Idealmente, elige la resolución nativa de su pantalla.\n\n"
                         + "Valores inferiores mejoran el rendimiento (pero en este caso veer la configuración de \"Interfaz\")"
                         ;
                default:
                    return "The resolution for main rendering. It should be your native screen resolution.\n\n"
                         + "Lower values offer better performance (but in this case see \"User interface\" setting)"
                         ;
            }
        }

        public static string label_uiRes_contentLanguage(string language) {

            switch (language) {
                case "sp":
                    return "Interfaz";

                default:
                    return "Interface";
            }
        }

        public static string label_uiRes_toolTipLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Résolution utilisée par l'interface du jeu.\n\n"
                         + "Si la résolution de \"Rendu\" que vous avez choisie est votre résolution native d'écran, laisser sur \"= Rendu\".\n"
                         + "Sinon saisir la résolution native de votre écran."
                         ;
                case "sp":
                    return "Resolución utilizada para la interfaz del juego.\n\n"
                         + "Si la resolución \"Principal\" que ha escogido es su resolución nativa de pantalla, deje \"= Principal\".\n"
                         + "Si no, seleccione la resolución nativa de su pantalla."
                         ;
                default:
                    return "Resolution for in-game interface.\n\n"
                         + "If the resolution you chose for \"Render\" is your native screen resolution, leave this on \"= Rendering\".\n"
                         + "If not, set the native resolution of your screen."
                         ;
            }
        }

        public static string groupBox_dofOptions_headerLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Profondeur de champ";
                case "sp":
                    return "Profundidad del campo";
                default:
                    return "Depth of field";
            }
        }

        public static string label_dofOverrideRes_contentLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Résolution";
                case "sp":
                    return "Resolución";
                default:
                    return "Resolution";
            }
        }

        public static string label_dofOverrideRes_toolTipLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Change la résolution de Profondeur de Champ (PdC).\nPlus la valeur est élevée, plus les éléments distants seront nets.\n"
                         + "NE PAS CHOISIR LA MEME VALEUR QUE VOTRE RESOLUTION VERTICALE\n\n"
                         + "- 360 : Valeur par défaut\n"
                         + "- 540 : Le cône PdC commence à 960x540\n"
                         + "- 810 : Le cône PdC commence à 1440x810\n"
                         + "- 1080 : Le cône PdC commence à 1920x1080\n"
                         + "- 2160 : Le cône PdC commence à 3840x2160"
                         ;
                case "sp":
                    return "Cambia la resolución de la Profundidad del Campo (PdC).\nCuanta más la valor está alta, más los elementos distantes serán netos.\n"
                         + "NO ELIGE EL MISMO VALOR QUE SU RESOLUCIÓN VERTICAL\n\n"
                         + "- 360 : Valor por defecto\n"
                         + "- 540 : El cono PdC empezas a 960x540\n"
                         + "- 810 : El cono PdC empezas a 1440x810\n"
                         + "- 1080 : El cono PdC empezas a 1920x1080\n"
                         + "- 2160 : El cono PdC empezas a 3840x2160"
                         ;
                default:
                    return "Change the Depth of Field (DoF) resolution.\nThe higher the value, the clearer the distant elements.\n"
                         + "DO NOT CHOOSE THE SAME VALUE AS YOUR VERTICAL RENDER RESOLUTION\n\n"
                         + "- 360 : Default value\n"
                         + "- 540 : DoF pyramid starts at 960x540\n"
                         + "- 810 : DoF pyramid starts at 1440x810\n"
                         + "- 1080 : DoF pyramid starts at 1920x1080\n"
                         + "- 2160 : DoF pyramid starts at 3840x2160"
                         ;
            }
        }

        public static string label_dofAdditionalBlur_contentLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Flou";
                case "sp":
                    return "Desenfoque";
                default:
                    return "Blur";
            }
        }

        public static string label_dofAdditionalBlur_toolTipLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Applique du flou supplémentaire sur l'effet de Profondeur de Champ (PdC).\n"
                         + "Permet de conserver l'effet de flou originel, même avec une résolution de PdC élevée.\n\n"
                         + "- Désactivé : Pas de flou\n"
                         + "- Défaut : Valeur par défaut (conseillé pour une résolution PdC de 540 ou 810)\n"
                         + "- Valeurs supérieures : pour les hautes résolutions de PdC"
                         ;
                case "sp":
                    return "Aplica mas desenfoque en el efecto de Profundidad de campo (PdC).\n"
                         + "Permite de conservar el efecto de desenfoque original, aunque con una resolución de PdC alta.\n\n"
                         + "- Desactivado : No desenfoque\n"
                         + "- Por defecto : Valor predeterminada (aconsejada para una resolución PdC de 540 o 810)\n"
                         + "- Valores superiores : para las resoluciones altas de PdC"
                         ;
                default:
                    return "Add additional blur on the Depth of Field (DoF) effect.\n"
                         + "Allows to get the originally intended effect of blur, even with high-resolution DoF settings.\n\n"
                         + "- Disabled : No blur\n"
                         + "- Default : Default value (recommended for a DoF resolution of 540 or 810)\n"
                         + "- Higher values : for high-resolution DoF settings"
                         ;
            }
        }

        public static string groupBox_aoOptions_headerLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Occlusion ambiante";
                case "sp":
                    return "Oclusión ambiental";
                default:
                    return "Ambient occlusion";
            }
        }

        public static string label_aoStrength_contentLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Intensité";
                case "sp":
                    return "Intensidad";
                default:
                    return "Strength";
            }
        }

        public static string label_aoStrength_toolTipLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Définit la présence de l'effet d'occlusion ambiante.\n\n"
                         + "- Désactivé : Occlusion ambiante désactivée\n"
                         + "- Élevé : Forte occlusion ambiante"
                         ;
                case "sp":
                    return "Define la intensidad del efecto de oclusión ambiental.\n\n"
                         + "- Desactivado : Oclusión ambiental desactivada\n"
                         + "- Alto : Oclusión ambiental intensa"
                         ;
                default:
                    return "Set the strength of the ambient occlusion effect.\n\n"
                         + "- Disabled : Disabled ambient occlusion\n"
                         + "- High : Strong ambient occlusion"
                         ;
            }
        }

        public static string label_aoType_contentLanguage(string language) {

            switch (language) {
                case "sp":
                    return "Tipo";
                default:
                    return "Type";
            }
        }

        public static string label_aoType_toolTipLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Définit le type d'Occlusion Ambiante à utiliser.\n\n"
                         + "- VSSAO : Volumetric SSAO\n"
                         + "- HBAO : Horizon-Based Ambient Occlusion\n"
                         + "- SCAO : VSSAO + HBAO\n"
                         + "- VSSAO2 : Volumetric SSAO with more samples (tweaked by Asmodean)"
                         ;
                case "sp":
                    return "Define el tipo de Oclusión ambiental utilisada.\n\n"
                         + "- VSSAO : Volumetric SSAO\n"
                         + "- HBAO : Horizon-Based Ambient Occlusion\n"
                         + "- SCAO : VSSAO + HBAO\n"
                         + "- VSSAO2 : Volumetric SSAO with more samples (tweaked by Asmodean)"
                         ;
                default:
                    return "Set the type of Ambient Occlusion to use.\n\n"
                         + "- VSSAO : Volumetric SSAO\n"
                         + "- HBAO : Horizon-Based Ambient Occlusion\n"
                         + "- SCAO : VSSAO + HBAO\n"
                         + "- VSSAO2 : Volumetric SSAO with more samples (tweaked by Asmodean)"
                         ;
            }
        }

        public static string checkBox_unlockFPS_contentLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Débloquer le framerate";
                case "sp":
                    return "Desbloquear framerate";
                default:
                    return "Unlock framerate";
            }
        }

        public static string checkBox_unlockFPS_toolTipLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Débloquer le framerate (taux d'images/secondes) pour être en mesure de dépasser 30fps.\n"
                         + "Peut provoquer quelques effets indésirables sur le gameplay."
                         ;
                case "sp":
                    return "Desbloquear el framerate (tasa imágenes/segundo) para superar los 30fps.\n"
                         + "Puede provocar efectos indeseables sobre la partida."
                         ;
                default:
                    return "Unlock the framerate, in order to be able to exceed 30fps.\n"
                         + "There may be unintended side-effects in term of gameplay."
                         ;
            }
        }

        public static string shared_maxFPSTarget_toolTipLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Définit le framerate maximum (fps = frame per second).\nLe framerate doit être débloqué pour atteindre 60fps.\n\n"
                         + "- 30fps : idéal pour garantir un framerate stable, ou pour un PC peu puissant\n"
                         + "- 60fps : choix le plus courant (possibilité de changer à la volée entre 30 et 60 fps en jeu)"
                         ;
                case "sp":
                    return "Define el framerate máximo (fps = frame per second).\nEl framerate tiene que estár desbloqueado par alcanzar 60fps.\n\n"
                         + "- 30fps : ideal para garantizar un framerate estable, o para un PC menos poderoso\n"
                         + "- 60fps : la opción más común (possibilidad de cambiar entre 30 y 60 fps durante la partida)"
                         ;
                default:
                    return "Set the maximum framerate to play at.\nThe framerate must be unlocked in order to achieve 60fps.\n\n"
                         + "- 30fps : to have a consistant framerate, or for a low-end PC\n"
                         + "- 60fps : most common choice (you can toggle 30/60 during the game)"
                         ;
            }
        }

        public static string label_toggleFramerateKey_contentLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Touche :";
                case "sp":
                    return "Tecla :";
                default:
                    return "Key :";
            }
        }

        public static string label_toggleFramerateKey_toolTipLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Définit la touche pour changer entre 30 et 60 fps pendant la partie";
                case "sp":
                    return "Define la tecla para cambiar entre 30 y 60 fps durante la partida";
                default:
                    return "Define the key to switch between 30 and 60 fps while in-game";
            }
        }

        public static string groupBox_mouseCursor_headerLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Curseur de la souris";
                case "sp":
                    return "Cursor del ratón";
                default:
                    return "Mouse cursor";
            }
        }

        public static string checkBox_showCursor_contentLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Afficher curseur";
                case "sp":
                    return "Mostrar cursor";
                default:
                    return "Display cursor";
            }
        }

        public static string checkBox_showCursor_toolTipLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Afficher le curseur de la souris pendant la partie.";
                case "sp":
                    return "Mostrar el cursor del raton durante el juego.";
                default:
                    return "Display the mouse cursor on screen while in-game.";
            }
        }

        public static string checkBox_captureCursor_contentLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Capturer curseur";
                case "sp":
                    return "Capturar cursor";
                default:
                    return "Capture cursor";
            }
        }

        public static string checkBox_captureCursor_toolTipLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Ne pas autoriser le curseur à sortir de la fenêtre de jeu.";
                case "sp":
                    return "No permite que el cursor salga de la ventana del juego.";
                default:
                    return "Do not allow the cursor to leave the game window.";
            }
        }

        public static string groupBox_controlOptions_headerLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Contrôles";
                case "sp":
                    return "Controles";
                default:
                    return "Controls";
            }
        }

        public static string radioButton_gamepad_contentLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Manette";
                case "sp":
                    return "Mando";
                default:
                    return "Gamepad";
            }
        }

        public static string radioButton_gamepad_toolTipLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Jouer à la manette (choix le plus courant)";
                case "sp":
                    return "Jugar con el mando (la opción más común)";
                default:
                    return "Play with gamepad (most common choice)";
            }
        }

        public static string label_gamepadButtonsStyle_contentLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Icônes";
                case "sp":
                    return "Iconos";
                default:
                    return "Icons";
            }
        }

        public static string label_gamepadButtonsStyle_toolTipLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Apparence des boutons de la manette";
                case "sp":
                    return "Apariencia de los botones de mando";
                default:
                    return "Look of the gamepad buttons";
            }
        }

        public static string radioButton_mouse_contentLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Souris";
                case "sp":
                    return "Ratón";
                default:
                    return "Mouse";
            }
        }

        public static string radioButton_mouse_toolTipLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Jouer à la souris (prise en charge améliorée grâce aux mods)";
                case "sp":
                    return "Jugar con el ratón (amejorado gracias a los mods)";
                default:
                    return "Play with mouse (better support thanks to mods)";
            }
        }

        public static string radioButton_oldMouseFix_contentLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Fix classique";
                case "sp":
                    return "Fix clásico";
                default:
                    return "Classic fix";
            }
        }

        public static string radioButton_oldMouseFix_toolTipLanguage(string language) {

            switch (language) {
                case "fr":
                    return "L'ancien fix, initialement réalisé par Petska, puis amélioré par Jellybaby34.";
                case "sp":
                    return "El antiguo fix, realizado originalmente por Petska y luego mejorado por Jellybaby34.";
                default:
                    return "The old fix, initially released by Petska, then improved by Jellybaby34.";
            }
        }

        public static string radioButton_newMouseFix_contentLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Nouveau fix";
                case "sp":
                    return "Nuevo fix";
                default:
                    return "New fix";
            }
        }

        public static string radioButton_newMouseFix_toolTipLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Le nouveau fix, par Methanhydrat";
                case "sp":
                    return "El nuevo fix, por Methanhydrat";
                default:
                    return "The new fix, by Methanhydrat";
            }
        }

        public static string button_configureMouse_contentLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Configurer souris";
                case "sp":
                    return "Configurar ratón";
                default:
                    return "Configure mouse";
            }
        }

        public static string groupBox_language_headerLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Langue";
                case "sp":
                    return "Idioma";
                default:
                    return "Language";
            }
        }

        public static string label_forceLanguage_contentLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Forcer langue :";
                case "sp":
                    return "Forzar idioma :";
                default:
                    return "Force language :";
            }
        }

        public static string label_forceLanguage_toolTipLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Force l'utilisation d'une langue dans le jeu.\n\n- Off : utiliser la langue définie dans Steam.";
                case "sp":
                    return "Forza la utilisación de un idioma específico durante el juego.\n\n- Off : utilizar el idioma definido en Steam.";
                default:
                    return "Force the use of a specific language in-game.\n\n- Off : use the language defined by Steam.";
            }
        }

        public static string checkBox_overlayDspw_contentLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Afficher l'overlay au lancement";
                case "sp":
                    return "Mostrar overlay al lanzamiento";
                default:
                    return "Display overlay at launch";
            }
        }

        public static string checkBox_overlayDspw_toolTipLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Définit si la barre d'informations de PvP Watchdog est affichée au démarrage du jeu.\n"
                         + "(indique la version utilisée, le nombre de nodes collectés, des informations sur les joueurs rencontrés, etc ...)\n\n"
                         + "Touche pour afficher/masquer en jeu : F9 (par défaut)."
                         ;
                case "sp":
                    return "Define si la barra de información de PvP Watchdog aparece al lanzamiento del juego.\n"
                         + "(indica la versión que está utilizando, el número de nodes, información sobre los jugadores encontrados, etc ...)\n\n"
                         + "Tecla para mostrar/esconder en juego : F9 (por defecto)."
                         ;
                default:
                    return "Define if the overlay of PvP Watchdog is displayed at game launch\n"
                         + "(shows version, node count, information on players you meet, etc ...)\n\n"
                         + "Key to toggle the display in-game : F9 (default)."
                         ;
            }
        }

        public static string checkBox_sweetFX_contentLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Utiliser SweetFX";
                case "sp":
                    return "Utilizar SweetFX";
                default:
                    return "Use SweetFX";
            }
        }

        public static string checkBox_sweetFX_toolTipLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Définit si SweetFX est utilisé durant la partie.\n\n"
                         + "La non-utilisation de ce mod peut améliorer le framerate, "
                         + "mais aussi aider à résoudre les problèmes liés au chaînage DLL."
                         ;
                case "sp":
                    return "Define si SweetFX está utilizado durante la partida.\n\n"
                         + "La no utilización de este mod puede mejorar el framerate, "
                         + "o ayudar a resolver problemas con al encadenamiento de DLL"
                         ;
                default:
                    return "Define if SweetFX is used in-game.\n\n"
                         + "Disable the mod can improve framerate, or help to solve issues relative to DLL chaining."
                         ;
            }
        }

        public static string label_sweetFxKey_contentLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Touche :";
                case "sp":
                    return "Tecla :";
                default:
                    return "Key :";
            }
        }

        public static string label_sweetFxKey_toolTipLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Définit la touche pour activer/désactiver SweetFX pendant la partie.";
                case "sp":
                    return "Define la tecla para activar/desactivar SweetFX durante el juego.";
                default:
                    return "Define the key to enable/disable SweetFX in-game.";
            }
        }

        public static string label_sweetFxPreset_toolTipLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Définit le préréglage à utiliser avec SweetFX.";
                case "sp":
                    return "Define el preajuste a utilizar con SweetFX.";
                default:
                    return "Define the preset to use with SweetFX.";
            }
        }

        public static string checkBox_FPSFix_contentLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Utiliser FPSFix+";
                case "sp":
                    return "Utilizar FPSFix+";
                default:
                    return "Use FPSFix+";
            }
        }

        public static string checkBox_FPSFix_toolTipLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Définit si FPSFix+ est utilisé durant la partie";
                case "sp":
                    return "Define si FPSFix+ está utilizado durante la partida";
                default:
                    return "Define if FPSFix+ is used in-game";
            }
        }

        public static string checkbox_FPSFixBeep_contentLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Activer bip";
                case "sp":
                    return "Activar pitido";
                default:
                    return "Enable beep";
            }
        }

        public static string checkbox_FPSFixBeep_toolTipLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Émettre un bip à chaque fois que le fix est automatiquement appliqué ?";
                case "sp":
                    return "¿ Emitir un pitido cuando el fix se aplica automáticamente ?";
                default:
                    return "Play a sound each time the fix is automatically triggered ?";
            }
        }

        public static string button_saveAndExit_contentLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Sauver et quitter";
                case "sp":
                    return "Guardar y salir";
                default:
                    return "Save and exit";
            }
        }

        #endregion

        #region MainLauncher - GUI items

        public static string button_DATAfolder_toolTipLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Ouvre le dossier DATA";
                case "sp":
                    return "Abre la carpeta DATA";
                default:
                    return "Open DATA folder";
            }
        }

        public static string button_DSMIsRootfolder_toolTipLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Ouvre le dossier racine de DSMI";
                case "sp":
                    return "Abre la carpeta raíz de DSMI";
                default:
                    return "Open DSMI root folder";
            }
        }

        public static string button_play_contentLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Jouer";
                case "sp":
                    return "Jugar";
                default:
                    return "Play";
            }
        }

        public static string button_gameSettings_contentLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Reglages";
                case "sp":
                    return "Opciones";
                default:
                    return "Settings";
            }
        }

        public static string button_install_contentLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Installer mods";
                case "sp":
                    return "Instalar mods";
                default:
                    return "Install mods";
            }
        }

        public static string button_projectSettings_contentLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Reglages du projet";
                case "sp":
                    return "Ajustes del proyecto";
                default:
                    return "Project settings";
            }
        }

        public static string button_uninstall_contentLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Desinstaller mods";
                case "sp":
                    return "Desinstalar mods";
                default:
                    return "Uninstall mods";
            }
        }

        #endregion

        #region ProjectSettings - GUI items

        public static string label_dataPathLocation_contentLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Emplacement du dossier DATA :";
                case "sp":
                    return "Ubicación de la carpeta DATA :";
                default:
                    return "Location of the DATA directory :";
            }
        }

        public static string button_browseDataPath_contentLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Parcourir ...";
                case "sp":
                    return "Buscar ...";
                default:
                    return "Browse ...";
            }
        }

        public static string dialog_browseDatapath_descriptionLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Sélectionner le dossier DATA de Dark Souls: Prepare to Die Edition";
                case "sp":
                    return "Seleccionar la carpeta DATA de Dark Souls: Prepare to Die Edition";
                default:
                    return "Select the DATA folder of Dark Souls: Prepare to Die Edition";
            }
        }

        public static string label_languageChoice_contentLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Langue à utiliser dans le projet :";
                case "sp":
                    return "Idioma utilizado en el proyecto :";
                default:
                    return "Language to use in project :";
            }
        }

        public static string label_compatibilityMode_contentLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Prise en charge des mods :";
                case "sp":
                    return "Mods detección :";
                default:
                    return "Mods support :";
            }
        }

        public static string radioButton_minMode_contentLanguage(string language) {

            switch (language) {
                case "sp":
                    return "Mínimo";
                default:
                    return "Minimal";
            }
        }

        public static string button_Apply_contentLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Sauver et quitter";
                case "sp":
                    return "Guardar y salir";
                default:
                    return "Save and exit";
            }
        }

        #endregion

        #region Uninstaller - GUI items

        public static string groupBox_UninstallOptions_headerLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Que supprimer dans le dossier DATA ?";
                case "sp":
                    return "¿ Qué eliminar en la carpeta DATA ?";
                default:
                    return "What to delete in the DATA directory ?";
            }
        }

        public static string radioButton_uninstallDsmiFiles_contentLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Uniquement les fichiers/dossiers de DSMI";
                case "sp":
                    return "Archivos/carpetas de DSMI solamente";
                default:
                    return "DSMI mods files/folders only";
            }
        }

        public static string radioButton_uninstallMostElements_contentLanguage(string language) {

            switch (language) {
                case "fr":
                    return "La majorité des fichiers/dossiers non vanilla";
                case "sp":
                    return "La mayoría de los archivos/carpetas non-vanilla";
                default:
                    return "Most non-vanilla files/folders";
            }
        }

        public static string radioButton_uninstallAllContent_contentLanguage(string language) {

            switch (language) {
                case "fr":
                    return "L'intégralité des fichiers/dossiers non vanilla";
                case "sp":
                    return "Cada archivos/carpetas non-vanilla";
                default:
                    return "Every non-vanilla files/folders";
            }
        }

        public static string radioButton_uninstallDsmiFiles_toolTipLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Choisissez cette option pour ne supprimer que les fichiers/dossiers qui sont installés par l'installateur de DSMI\n"
                         + "(si ils existent)\n\nVoir les fichiers README pour savoir quels mods sont concernés, selon la version de DSMI."
                         ;
                case "sp":
                    return "Elija esta opción para eliminar solamente los archivos/carpetas que están instalados por el instalador de DSMI\n"
                         + "(si existen)\n\nConsulte los archivos README para ver qué modificaciones se refiere, según la versión de DSMI que utiliza."
                         ;
                default:
                    return "Choose this option to delete only the files/folders that\nwere installed with DSMI Installer (if they exist)\n\n"
                         + "Refer to the README files to know which mods are going to\nbe uninstalled, depending on the version of DSMI you have."
                         ;
            }
        }

        public static string radioButton_uninstallMostElements_toolTipLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Choisissez cette option pour supprimer la majorité des éléments non vanilla (installés avec DSMI ou non).\n"
                         + "Notez que cela ne supprimera PAS les fichiers/dossiers obtenus avec le Wulf's BND Rebuilder ou les fichiers .bak.\n\n"
                         + "Par exemple, vous garderiez ces éléments :\n"
                         + "- dossiers map, sound, etc ... extraits depuis les archives dvdbnd*\n"
                         + "- dossiers dvdbnd[0-3].bhd5.extract\n"
                         + "- fichiers dvdbnd[0-3].[bdt-bhd5].bak\n"
                         + "- fichier DARKSOULS.exe.bak"
                         ;
                case "sp":
                    return "Elija esta opción para eliminar la mayoría de los elementos encontrados que no sean original (instalados con DSMI o no).\n"
                         + "Observación : Esto NO eliminará los archivos/carpetas obtenidos con el Wulf's BND Rebuilder o los archivos .bak.\n\n"
                         + "Por ejemplo, esto conservaría estos elementos :\n"
                         + "- carpetas map, sound, etc ... recuperadas de los archivos dvdbnd*\n"
                         + "- carpetas dvdbnd[0-3].bhd5.extract\n"
                         + "- archivos dvdbnd[0-3].[bdt-bhd5].bak\n"
                         + "- archivo DARKSOULS.exe.bak"
                         ;
                default:
                    return "Choose this option to delete most non-vanilla elements found\n(installed with DSMI or not).\nNote that this would NOT "
                         + "delete the files/folders that you may got from using Wulf's BND Rebuilder or any .bak files.\n\n"
                         + "For instance, you would keep these elements :\n"
                         + "- folders map, sound, etc ... extracted from dvdbnd* archives\n"
                         + "- folders dvdbnd[0-3].bhd5.extract\n"
                         + "- files dvdbnd[0-3].[bdt-bhd5].bak\n"
                         + "- file DARKSOULS.exe.bak"
                         ;
            }
        }

        public static string radioButton_uninstallAllContent_toolTipLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Choisissez cette option pour supprimer tout élément non vanilla trouvé\n(installé avec DSMI ou non)\n\n"
                         + "Cela restaurera (le dossier DATA de) Dark Souls à l'état vanilla peu importe son état actuel."
                         ;
                case "sp":
                    return "Elija esta opción para eliminar todos los elementos encontrados que no sean original\n(instalados con DSMI o no)\n\n"
                         + "Eso invertirá (la carpeta DATA de) Dark Souls volver al estado original no importa su estado actual."
                         ;
                default:
                    return "Choose this option to delete all non-vanilla elements found\n(installed with DSMI or not)\n\n"
                         + "That will reverse (the DATA folder of) Dark Souls back to vanilla state no matter what."
                         ;
            }
        }

        public static string button_proceed_contentLanguage(string language) {

            switch (language) {
                case "fr":
                    return "Désinstaller";
                case "sp":
                    return "Desinstalar";
                default:
                    return "Uninstall";
            }
        }

        #endregion


        #region Other texts

        public static string CustomButtonText_DontWarn(string language) {

            switch (language) {
                case "fr":
                    return "Ne plus m'avertir";
                case "sp":
                    return "No avisarme";
                default:
                    return "Don't warn me again";
            }
        }


        //////////   ERRORS   ////////////////////////////////////////////////

        public static string ErrorMsg_controllerButtonTexturesCopyFailed(string folder, string language) {

            switch (language) {
                case "fr":
                    return "Erreur pendant la copie des textures de boutons de manette.\nVérifier manuellement dans ce dossier :\n\n"
                          + folder;
                case "sp":
                    return "Error al copiar las texturas de los botones de mando.\nPor favor compruebe manualmente en esta carpeta: :\n\n"
                          + folder;
                default:
                    return "Error copying the textures files for gamepad icons.\nCheck manually within that folder :\n\n"
                          + folder;
            }
        }

        public static string ErrorMsg_dsmfixGuiNotFound(string program, string language) {

            switch (language) {
                case "fr":
                    return "Erreur : Programme de configuration de souris \"" + program + "\" introuvable !";
                case "sp":
                    return "¡ Error : El programa de configuración del ratón \"" + program + "\" no es encontrado !";
                default:
                    return "Error : Mouse configuration program \"" + program + "\" not found !";
            }
        }

        public static string ErrorMsg_errorWhileUninstalling(string language) {

            switch (language) {
                case "fr":
                    return "Erreur lors de l'installation !\nVérifiez que vous n'êtes pas en train d'utiliser un des fichiers à supprimer.";
                case "sp":
                    return "¡ Error durante la instalación !\nAsegúrese de que no está utilizando los archivos que desea eliminar";
                default:
                    return "Error while uninstalling !\nMake sure you are not using the files to delete.";
            }
        }

        public static string ErrorMsg_invalidDataPath(string language) {

            switch (language) {
                case "fr":
                    return "Erreur : L'emplacement spécifié pour le dossier DATA est invalide !\n\n"
                         + "Veuillez vérifier les réglages du projet, puis réessayez.";
                case "sp":
                    return "¡ Error : La ubicación especificada para la carpeta DATA está inválida !\n\n"
                         + "Por favor compruebe los ajustes del proyecto y intente de nuevo.";
                default:
                    return "Error : The specified path to the DATA folder is invalid !\n\n"
                         + "Please check the project settings, then try again.";
            }
        }

        public static string ErrorMsg_invalidLauncher(string language) {

            switch (language) {
                case "fr":
                    return "Emplacement(s) invalide(s) dans le launcher existant.\nCliquez sur OK pour en générer un nouveau.";
                case "sp":
                    return "Ubicación(es) inválida(s) en el launcher existente.\nPulse la tecla OK para generarlo de nuevo.";
                default:
                    return "Invalid path(s) in the existing launcher.\nClick OK to generate another one.";
            }
        }

        public static string ErrorMsg_invalidDataPath_projectSettings(string language) {

            switch (language) {
                case "fr":
                    return "Erreur : Emplacement du dossier DATA invalide !\n"
                         + "Veuillez utiliser le bouton \"Parcourir...\" pour le définir manuellement.";
                case "sp":
                    return "¡ Error : La ubicación de la carpeta DATA está inválida !\n"
                         + "Por favor utiliza el botón \"Buscar...\" para definirlo manualmente.";
                default:
                    return "Error : Invalid DATA folder path :\n"
                         + "Please use the \"Browse...\" button to define it manually.";
            }
        }

        public static string ErrorMsg_missingDll(string file, string language) {

            switch (language) {
                case "fr":
                    return "Erreur : Fichier \"" + file + "\" introuvable !\n\n"
                         + "Vérifiez votre installation, puis réessayez.";
                case "sp":
                    return "¡ Error : El archivo \"" + file + "\" no es encontrado !\n\n"
                         + "Compruebe su instalación y intente de nuevo.";
                default:
                    return "Error : File \"" + file + "\" not found !\n\n"
                         + "Please check your setup then try again.";
            }
        }

        public static string ErrorMsg_missingFiles(string mod_name, string language) {

            switch (language) {
                case "fr":
                    return "Erreur : Des fichiers du mod \"" + mod_name + "\" sont introuvables dans le dossier DATA !\n\n"
                         + "Vérifiez votre installation, puis réessayez.";
                case "sp":
                    return "¡ Error : Algunos archivos del mod \"" + mod_name + "\" no son encontrados en la carpeta DATA !\n\n"
                         + "Compruebe su instalación y intente de nuevo.";
                default:
                    return "Error : Some files of the mod \"" + mod_name + "\" are not found in the DATA directory !\n\n"
                         + "Please check your setup then try again.";
            }
        }

        public static string ErrorMsg_NBGIfileNotFound(string file, string language) {

            switch (language) {
                case "fr":
                    return "Erreur : Fichier \"" + file + "\" introuvable !\n\n"
                         + "Lancez puis quittez Dark Souls une fois afin de le (re)générer, puis réessayez.";
                case "sp":
                    return "¡ Error : El archivo \"" + file + "\" no es encontrado !\n\n"
                         + "Ejecute Dark Souls una vez para generarlo y intente de nuevo.";
                default:
                    return "Error : File \"" + file + "\" not found !\n\n"
                         + "Run and exit Dark Souls once to generate it, then try again.";
            }
        }

        public static string ErrorMsg_noMouseFixChosen(string language) {

            switch (language) {
                case "fr":
                    return "Erreur : Vous devez spécifier quel fix utiliser pour la souris !";
                case "sp":
                    return "¡ Error : Tiene que elegir qué fix utilizar para el ratón !";
                default:
                    return "Error : You have to specify the fix to use for the mouse !";
            }
        }

        public static string ErrorMsg_noOptionsSelected(string language) {

            switch (language) {
                case "fr":
                    return "Erreur : Vous devez choisir une option pour désinstaller !";
                case "sp":
                    return "Error : ¡ Debe elegir una opción para desinstalar !";
                default:
                    return "Error : You must choose an option to uninstall !";
            }
        }

        public static string ErrorMsg_nothingToUninstall(string language) {

            switch (language) {
                case "fr":
                    return "Erreur : Aucun fichier à désinstaller n'a été trouvé !";
                case "sp":
                    return "Error : ¡ Ningún archivo se encontró para la desinstalación !";
                default:
                    return "Error : No files to uninstall were found !";
            }
        }

        public static string ErrorMsg_projectSettingsFileNotFound(string language) {

            switch (language) {
                case "fr":
                    return "Erreur : Fichier \"DSMI_settings.txt\" introuvable !\n"
                         + "Rendez-vous dans les \"Reglages du projet\" pour le créer, puis réessayez.";
                case "sp":
                    return "¡ Error : Archivo \"DSMI_settings.txt\" no es encontrado !\n"
                         + "Vaya en \"Ajustes del proyecto\" para generarlo y intente de nuevo.";
                default:
                    return "Error : File \"DSMI_settings.txt\" not found !\n"
                         + "Please go in \"Project Settings\"to create it, then try again.";
            }
        }

        public static string ErrorMsg_programNotFound(string file, string language) {

            switch (language) {
                case "fr":
                    return "Erreur : Programme \"" + file + "\" introuvable.\nVeuillez vérifier votre installation.";
                case "sp":
                    return "Error : Programa \"" + file + "\" inencontrable.\nPor favor verifique su instalación.";
                default:
                    return "Error : Program \"" + file + "\" not found.\nPlease check your setup.";
            }
        }

        public static string ErrorMsg_wrongDataPath(string language) {

            switch (language) {
                case "fr":
                    return "L'emplacement du dossier DATA, spécifié dans les Réglages du projet, semble invalide : "
                         + "les fichiers \"fmodex.dll\" et \"fmod_event.dll\" doivent exister dans ce répertoire !\n\n"
                         + "Utilisez l'option \"Reglages du projet\" pour définir le bon emplacement.";
                case "sp":
                    return "La ubicación de la carpeta DATA, especificada en los Ajustes del proyecto, parece estar inválida : "
                         + "los archivos \"fmodex.dll\" y \"fmod_event.dll\" tienen estar localizados en este directorio.\n\n"
                         + "Utiliza de nuevo la opción \"Ajustes del proyecto\" para definir la ubicación correcta.";
                default:
                    return "The DATA folder path specified in Project settings appears to be invalid : "
                         + "files \"fmodex.dll\" and \"fmod_event.dll\" must exist within that directory !\n\n"
                         + "Use \"Project settings\" to define the right location.";
            }
        }

        public static string ErrorMsg_wrongResolutionChoice(string language) {

            switch (language) {
                case "fr":
                    return "Erreur : Choix de résolution incorrect !\n\n"
                         + "Si la résolution de Rendu est inférieure à 1280x720, "
                         + "vous devez spécifier une résolution différente pour l'Interface.";
                case "sp":
                    return "¡ Error : Ajustes de resolución incorrectos !\n\n"
                         + "Si la resolución Principal es inferior a 1280x720, "
                         + "debe elegir una otra resolución para la Interfaz.";
                default:
                    return "Error : Wrong choice of resolution !\n\n"
                         + "If the Rendering resolution is lower than 1280x720, "
                         + "you must choose a different resolution for the Interface.";
            }
        }

        public static string ErrorMsg_unableToReachFilesAtInstall(string language) {
            switch (language) {
                case "fr":
                    return "Erreur : Dossier \\Source\\ de DSMI inaccessible ou inexistant !";
                case "sp":
                    return "Error : La carpeta \\Source\\ de DSMI esta inaccesible o inencontrable.";
                default:
                    return "Error : DSMI's \\Source\\ folder is unreachable or don't exist !";
            }
        }


        //////////  MESSAGES  ////////////////////////////////////////////////

        public static string Message_appliedSettings(string language) {

            switch (language) {
                case "fr":
                    return "Appliqué.";
                case "sp":
                    return "Aplicado.";
                default:
                    return "Applied.";
            }
        }

        public static string Message_installationCompleted(string language) {

            switch (language) {
                case "sp":
                    return "Instalación OK.";
                default:
                    return "Installation OK";
            }
        }

        public static string Message_launcherCreated(string language) {

            switch (language) {
                case "fr":
                    return "Launcher créé avec succès !";
                case "sp":
                    return "¡ Launcher creado correctamente !";
                default:
                    return "Launcher created successfully !";
            }
        }

        public static string Message_launcherCreationFailed_noDSCM(string language) {

            switch (language) {
                case "fr":
                    return "Erreur lors de la création du launcher à l'aide du registre Windows.\n"
                         + "DSCM est introuvable dans le dossier DATA : avez-vous installé les mods ?";
                case "sp":
                    return "Error al crear el launcher con operaciones de registro de Windows.\n"
                         + "DSCM inencontrable en la carpeta DATA : ¿ Instaló los mods ?";
                default:
                    return "Error creating the launcher with Windows registry.\n"
                         + "DSCM not found in the DATA folder : have you really installed mods ?";
            }
        }

        public static string Message_launcherCreationFailed_noSteam(string language) {

            switch (language) {
                case "fr":
                    return "Erreur lors de la création du launcher à l'aide du registre Windows.\n"
                         + "Steam est introuvable : l'avez-vous installé ?";
                case "sp":
                    return "Error al crear el launcher con operaciones de registro de Windows.\n"
                         + "Steam inencontrable : por favor verifique su installacion.";
                default:
                    return "Error creating the launcher with Windows registry.\n"
                         + "Steam not found : do you really have it installed ?";
            }
        }

        public static string Message_noLauncher(string language) {

            switch (language) {
                case "fr":
                    return "Launcher introuvable. Cliquez sur OK pour le générer.";
                case "sp":
                    return "Launcher inencontrable. Pulse tecla OK para generarlo.";
                default:
                    return "Launcher not found. Click OK to generate it.";
            }
        }

        public static string Message_settingsApplied(string language) {

            switch (language) {
                case "fr":
                    return "Appliqué. Le projet est maintenant en Français.";
                case "sp":
                    return "Aplicado. El proyecto está ahora en Español.";
                default:
                    return "Applied. Project is now in English.";
            }
        }

        public static string Message_uninstalledElements(int fileCount, int folderCount, string language) {

            switch (language) {
                case "fr":
                    return "Terminé : " + fileCount + " fichier(s) et " + folderCount + " dossier(s) supprimé(s).";
                case "sp":
                    return "Hecho : " + fileCount + " archivo(s) y " + folderCount + " carpeta(s) eliminado.";
                default:
                    return "Done : " + fileCount + " file(s) and " + folderCount + " folder(s) deleted.";
            }
        }

        //////////  WARNINGS  ////////////////////////////////////////////////

        public static string Warning_installContent(string language) {

            switch (language) {
                case "fr":
                    return "Êtes-vous sûr ?\n\n"
                         + "Des mods installés par DSMI semblent déjà exister dans le dossier DATA : "
                         + "cette opération d'installation remplacera les fichiers/dossiers déjà existants.";
                case "sp":
                    return "¿ Está seguro ?\n\n"
                         + "Algunos mods de DSMI ya parecen existir en la carpeta DATA : "
                         + "esta operación de instalación reemplazará los archivos/carpetas ya existentes.";
                default:
                    return "Are you sure ?\n\n"
                         + "Some mods installed by DSMI seem to already exist in the DATA folder : "
                         + "this installation operation will replace these files/folders if they already exist.";
            }
        }

        public static string Warning_installHeader(string language) {

            switch (language) {
                case "sp":
                    return "Confirmación";
                default:
                    return "Confirmation";
            }
        }

        public static string Warning_uninstallAllContent(string language) {

            switch (language) {
                case "fr":
                    return "Êtes-vous sûr ?\nCela supprimera aussi les fichiers .bak que vous pourriez avoir !";
                case "sp":
                    return "¿ Estás seguro ?\n¡ Este eliminará los archivos .bak que pueda tener !";
                default:
                    return "Are you sure ?\nIt will even delete the .bak files you may have !";
            }
        }

        public static string Warning_uninstallAllHeader(string language) {

            switch (language) {
                case "sp":
                    return "Confirmación";
                default:
                    return "Confirmation";
            }
        }

        public static string Warning_unsupportedButtonTextures(string folder, string language) {

            switch (language) {
                case "fr":
                    return "Les fichiers \"40fbc4ad.png\" et/ou \"43a2b23a.png\" existent mais ne sont pas supportés par DSMI. "
                         + "Pour continuer à utiliser ces textures, laissez le réglage \"Icônes\" de manette sur \"Personnalisé\".\n\n"
                         + "Ces textures sont situées dans le dossier :\n" + folder;
                case "sp":
                    return "Los archivos \"40fbc4ad.png\" y/o \"43a2b23a.png\" existen pero no son compatibles con DSMI. "
                         + "Para seguir utilizando estas texturas, deje el ajuste de los \"Iconos\" de mando en la opción \"Personalizado\".\n\n"
                         + "Estas texturas se encuentran en la carpeta :\n" + folder;
                default:
                    return "Files \"40fbc4ad.png\" and/or \"43a2b23a.png\" exist but are not supported by DSMI.\n"
                         + "To keep using these particular textures, let the gamepad setting \"Icons\" set on \"Custom\".\n\n"
                         + "These textures are located in the folder :\n" + folder;
            }
        }

        public static string Warning_wrongLoadedData(string language) {

            switch (language) {
                case "fr":
                    return "Attention : Valeur(s) introuvable(s) dans les fichiers de configuration !\n"
                         + "Certains réglages peuvent ne pas fonctionner.\n\n"
                         + "Veuillez vérifier l'intégrité des fichiers.\n\n\n"
                         + "(GUI) VALEURS NON TROUVÉES :\n";
                case "sp":
                    return "¡ Cuidado : Valor(es) no encontrado(s) en los archivos de configuración !\n"
                         + "Algunos ajustes podría no funcionar.\n\n"
                         + "Compruebe la integridad de los archivos.\n\n\n"
                         + "(GUI) VALORES NO ENCONTRADOS :\n";
                default:
                    return "Warning : Value(s) not found within the configuration files !\n"
                         + "Some settings may not work.\n\n"
                         + "Please check file integrity.\n\n\n"
                         + "(GUI) VALUES NOT FOUND :\n";
            }
        }


        #endregion

    }
}
