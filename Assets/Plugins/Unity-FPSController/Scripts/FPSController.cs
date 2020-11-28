using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bytes.Controllers
{
    /// <summary>
    /// Basic FPSController
    /// </summary>
    public class FPSController : MonoBehaviour
    {
        public float walkingSpeed = 5.5f;               // Vitesse du personnage en marchant
        public float runningSpeed = 9.0f;               // Vitesse du personnage en courant
        public float mouseSensitivy = 1.5f;             // Mouvement de rotation plus grande du personnage selon cette sensibilité
        public bool canBeControlled = true;             // Si false, empêche le joueur d'être contrôlé
        public bool overrideMouse = true;               // Is mouse disactivated by this controller
        private bool _Running = false;                  // Détermine si le joueur est en train de courir

        [Header("References")]
        private Camera _CameraJoueur;                   // Référence à la Camera du joueur
        private Rigidbody _JoueurRg;                    // Référence au Rigidbody du joueur

        /// <summary>
        /// Initialisation des références
        /// </summary>
        protected virtual void Awake()
        {
            _JoueurRg = GetComponent<Rigidbody>();
            if (_CameraJoueur == null) { _CameraJoueur = transform.Find("CameraParent").transform.Find("Camera").GetComponent<Camera>(); }
        }

        /// <summary>
        /// Initialisation des valeurs
        /// </summary>
        public virtual void Initialize()
        {

        }

        /// <summary>
        /// Tout les contrôles du joueur incluants la marche, la caméra et plus ( voir les commentaires de ces 3 fonctions
        /// </summary>
        protected virtual void Update()
        {
            // Si les controlles sont possibles
            if (!canBeControlled) { return; }
            _Movement_Update();
            _Camera_Update();
            _Controls_Update();
        }

        /// <summary>
        /// S'occupe de tout les contrôles sauf de la caméra et du mouvement du joueur, appelé dans Update à chaque frame
        /// </summary>
        protected virtual void _Controls_Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0)) { Cursor.visible = false; Cursor.lockState = CursorLockMode.Locked; }

            // Animation course
            if (Input.GetKey(KeyCode.LeftShift) && !_Running)
                _ToogleCourse();
            else if (Input.GetKeyUp(KeyCode.LeftShift) && _Running)
                _ToogleCourse();
        }

        /// <summary>
        /// Fonction qui s'occupe du mouvement du joueur en entier, appelée dans Update à chaque frame
        /// </summary>
        protected virtual void _Movement_Update()
        {
            float horiz = Input.GetAxisRaw("Horizontal");
            float vert = Input.GetAxisRaw("Vertical");

            Vector3 mouvementDeCoter;
            Vector3 mouvementAvant;

            float vitesse = (_Running) ? runningSpeed : walkingSpeed;
            bool deuxDirectionEnMemeTemps = (Mathf.Abs(horiz) == 1 && Mathf.Abs(vert) == 1) ? true : false;

            mouvementDeCoter = transform.right * horiz * vitesse / ((deuxDirectionEnMemeTemps) ? 1.5f : 1);
            mouvementAvant = transform.forward * vert * vitesse / ((deuxDirectionEnMemeTemps) ? 1.5f : 1);

            // GetComponent<Rigidbody>().velocity = (mouvementAvant + mouvementDeCoter);//Le dernier vecteur ajoute de la force vers le sol et empêche ainsi le joueur de flotter
            GetComponent<Rigidbody>().velocity = (mouvementAvant + mouvementDeCoter + new Vector3(0, -3, 0));
        }

        /// <summary>
        /// Fonction qui s'occupe du mouvement de la caméra du joueur
        /// </summary>
        protected virtual void _Camera_Update()
        {
            float mouseX = Input.GetAxisRaw("Mouse X");
            float mouseY = Input.GetAxisRaw("Mouse Y");

            float rotAmountX = mouseX * mouseSensitivy; // Puisque l'axe horizontale est en Y, rotAmountX = rotation en y
            float rotAmountY = mouseY * mouseSensitivy; // Puisque l'axe verticale est en X, rotAmountY = rotation en x

            Vector3 rotationCamera = _CameraJoueur.transform.localRotation.eulerAngles;
            Vector3 rotationCorps = transform.rotation.eulerAngles;

            rotationCamera.x -= rotAmountY; // le - exprime l'inversion de la rotation
            rotationCamera.z = 0; // Empêche la rotation en Z
            rotationCorps.y += rotAmountX; // Rotation en Y

            // Transformation de l'angle
            var angle = rotationCamera.x;
            angle = (angle > 180) ? angle - 360 : angle;
            angle = Mathf.Clamp(angle, -90, 90);

            //limite l'angle de la caméra en Verticale
            rotationCamera.x = angle;

            //Rotation de la caméra du joueur
            _CameraJoueur.transform.localRotation = Quaternion.Euler(rotationCamera);

            //Rotation du corps du joueur
            transform.rotation = Quaternion.Euler(rotationCorps);
        }

        protected virtual void _ToogleCourse()
        {
            _Running = !_Running;
        }

    }
}
