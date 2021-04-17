import firebase from 'firebase/app';
// Add the Firebase products that you want to use
import "firebase/auth";
import "firebase/firestore";

class FirebaseAuthBackend {
    constructor(firebaseConfig) {
        if (firebaseConfig) {
            // Initialize Firebase
            firebase.initializeApp(firebaseConfig);
            firebase.auth().onAuthStateChanged((user) => {
                if (user) {
                    sessionStorage.setItem("authUser", JSON.stringify(user));
                } else {
                    sessionStorage.removeItem('authUser');
                }
            });
        }
    }

    /**
     * Registers the user with given details
     */
    registerUser = (email, password) => {
        return new Promise((resolve, reject) => {
            firebase.auth().createUserWithEmailAndPassword(email, password).then((user) => {
                // eslint-disable-next-line no-redeclare
                var user = firebase.auth().currentUser;
                resolve(user);
            }, (error) => {
                reject(this._handleError(error));
            });
        });
    }

    /**
     * Login user with given details
     */
    loginUser = (email, password) => {
        return new Promise((resolve, reject) => {
            firebase.auth().signInWithEmailAndPassword(email, password).then((user) => {
                // eslint-disable-next-line no-redeclare
                var user = firebase.auth().currentUser;
                resolve(user);
            }, (error) => {
                reject(this._handleError(error));
            });
        });
    }

    /**
     * forget Password user with given details
     */
    forgetPassword = (email) => {
        return new Promise((resolve, reject) => {
            firebase.auth().sendPasswordResetEmail(email, { url: window.location.protocol + "//" + window.location.host + "/login" }).then(() => {
                resolve(true);
            }).catch((error) => {
                reject(this._handleError(error));
            })
        });
    }

    /**
     * Logout the user
     */
    logout = () => {
        return new Promise((resolve, reject) => {
            firebase.auth().signOut().then(() => {
                resolve(true);
            }).catch((error) => {
                reject(this._handleError(error));
            })
        });
    }

    setLoggeedInUser = (user) => {
        sessionStorage.setItem("authUser", JSON.stringify(user));
    }

    /**
     * Returns the authenticated user
     */
    getAuthenticatedUser = () => {
        if (!sessionStorage.getItem('authUser'))
            return null;
        return JSON.parse(sessionStorage.getItem('authUser'));
    }

    /**
     * Handle the error
     * @param {*} error 
     */
    _handleError(error) {
        var errorMessage = error.message;
        return errorMessage;
    }
}

let _fireBaseBackend = null;

/**
 * Initilize the backend
 * @param {*} config 
 */
const initFirebaseBackend = (config) => {
    if (!_fireBaseBackend) {
        _fireBaseBackend = new FirebaseAuthBackend(config);
    }
    return _fireBaseBackend;
}

/**
 * Returns the firebase backend
 */
const getFirebaseBackend = () => {
    return _fireBaseBackend;
}

export { initFirebaseBackend, getFirebaseBackend };