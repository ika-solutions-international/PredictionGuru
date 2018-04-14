import React from 'react';
import { StyleSheet, Text, View } from 'react-native';

export default class App extends React.Component {
  render() {
    return (
        <View style={styles.container}>
            <View style={styles.topSection}>
                <Text style={styles.statusBarTex}>IKA Status Bar!</Text>
            </View>
            <View style={styles.middleSection}>
                <Text style={styles.blueBold}>Hello IKA World!!</Text>
            </View>
            <View style={styles.bottomSection}>
                <Text style={styles.footerTex}>Buttons will appear here</Text>
            </View>
      </View>
    );
  }
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
        backgroundColor: 'black',
        borderStyle: 'solid',
        borderColor: 'red',
        borderWidth: 1
    },
    blueBold: {
        color: 'blue',
        fontWeight: 'bold',
        fontSize: 30
    },
    topSection: {
        backgroundColor: "steelblue",
        height: 22,
        alignItems: 'center'
    },
    middleSection: {
        flex: 1,
        backgroundColor: "powderblue",
        alignItems: 'center',
        justifyContent: 'center'
    },
    bottomSection: {
        height: 50,
        backgroundColor: "skyblue",
        alignItems: 'center',
        justifyContent: 'center'
    },
    statusBarTex: {
        color: 'white',
        fontWeight: 'bold'
    },
    footerTex: {
        fontWeight: 'bold'
    }
});
